using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tomasos.Core.Interfaces;
using Tomasos.Domain.DTO;
using Tomasos.Infrastructure.Identity;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]



    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AdminController(
            IAdminService adminService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)

        {
            _adminService = adminService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginDTO adminLogin)
        {
           
            var user = await _userManager.FindByNameAsync(adminLogin.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, adminLogin.Password))
                return Unauthorized("Invalid credentials");

            // Hämta roller
            var roles = await _userManager.GetRolesAsync(user);

            // Skapa claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
    };
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // Skapa token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JwtSettings:ExpireMinutes"])),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }


        [AllowAnonymous]

        [HttpGet("get-all-customers")]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _adminService.GetAllCustomers();
            return Ok(customers);
        }

        [AllowAnonymous]
        [HttpGet("get-regular-customers")]
        public async Task<ActionResult<List<Customer>>> GetRegularCustomers()
        {
            return Ok(await _adminService.GetRegularCustomers());
        }

        [AllowAnonymous]
        [HttpGet("get-premium-customers")]
        public async Task<ActionResult<List<Customer>>> GetPremiumCustomers()
        {
            return Ok(await _adminService.GetPremiumCustomers());
        }

        [AllowAnonymous]
        [HttpPost("create-dish")]
        public async Task<IActionResult> CreateDish([FromBody] Dish dish)
        {
            await _adminService.CreateDish(dish);
            return Ok("Dish created");
        }

        [AllowAnonymous]
        [HttpPut("update-dish")]
        public async Task<IActionResult> UpdateDish([FromBody] Dish dish)
        {
            await _adminService.UpdateDish(dish);
            return Ok("Dish updated");
        }

        [AllowAnonymous]
        [HttpDelete("delete-order/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _adminService.DeleteOrder(orderId);
            return Ok("Order deleted");
        }

        [AllowAnonymous]
        [HttpPut("update-order-status/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            await _adminService.UpdateOrderStatus(orderId, status);
            return Ok("Order status updated");
        }

        [AllowAnonymous]
        [HttpPut("update-user-role")]
        public async Task<IActionResult> UpdateUserRole([FromQuery] string email, [FromQuery] string newRole)
        {

            if (!await _roleManager.RoleExistsAsync(newRole))
            {
                return BadRequest("Invalid role");
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return NotFound("User not found");

            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!result.Succeeded)
                return BadRequest("Failed to remove existing roles");

            var addResult = await _userManager.AddToRoleAsync(user, newRole);

            if (!addResult.Succeeded)
                return BadRequest("Failed to assign new role");

            return Ok($"User role updated to {newRole}");
        }

       




    }

}
