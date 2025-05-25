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
            if (adminLogin.AdminName == "JackAdmin" && adminLogin.Password == "jackadmin345!")
            {
                // Läs JWT-inställningar direkt från appsettings.json
                var secretKey = _configuration["JwtSettings:Secret"];
                var issuer = _configuration["JwtSettings:Issuer"];
                var audience = _configuration["JwtSettings:Audience"];
                var expireMinutes = int.Parse(_configuration["JwtSettings:ExpireMinutes"]);

                var claims = new[]
                {
            new Claim(ClaimTypes.Name, adminLogin.AdminName),
            new Claim(ClaimTypes.Role, "Admin")
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expireMinutes),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
            }

            return Unauthorized("Felaktiga inloggningsuppgifter");
        }




            [HttpGet("Get all customers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(await _adminService.GetAllCustomers());
        }


        [HttpGet("Get regular customers")]
        public async Task<ActionResult<List<Customer>>> GetRegularCustomers()
        {
            return Ok(await _adminService.GetRegularCustomers());
        }

        [HttpGet("Get premium customers")]
        public async Task<ActionResult<List<Customer>>> GetPremiumCustomers()
        {
            return Ok(await _adminService.GetPremiumCustomers());
        }


        [HttpPost("Create dish")]
        public async Task<IActionResult> CreateDish([FromBody] Dish dish)
        {
            await _adminService.CreateDish(dish);
            return Ok("Dish created");
        }

        [HttpPut("Update dish")]
        public async Task<IActionResult> UpdateDish([FromBody] Dish dish)
        {
            await _adminService.UpdateDish(dish);
            return Ok("Dish updated");
        }


        [HttpDelete("Delete order/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _adminService.DeleteOrder(orderId);
            return Ok("Order deleted");
        }
        [HttpPut("Update order status/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            await _adminService.UpdateOrderStatus(orderId, status);
            return Ok("Order status updated");
        }

        [HttpPut("Update user role")]
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
