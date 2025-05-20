using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tomasos.Core.Interfaces;
using Tomasos.Domain.Entities;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

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

        public AdminController(IAdminService adminService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _adminService = adminService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        //public async Task <IActionResult> LoginAdmin (Admin admin)
        //{
        //     return 
        //}

        [HttpGet("customers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(await _adminService.GetAllCustomers());
        }


        [HttpGet("customers/regular")]
        public async Task<ActionResult<List<Customer>>> GetRegularCustomers()
        {
            return Ok(await _adminService.GetRegularCustomers());
        }

        [HttpGet("customers/premium")]
        public async Task<ActionResult<List<Customer>>> GetPremiumCustomers()
        {
            return Ok(await _adminService.GetPremiumCustomers());
        }

        
        [HttpPost("dish")]
        public async Task<IActionResult> CreateDish([FromBody] Dish dish)
        {
            await _adminService.CreateDish(dish);
            return Ok("Dish created");
        }

        [HttpPut("dish")]
        public async Task<IActionResult> UpdateDish([FromBody] Dish dish)
        {
            await _adminService.UpdateDish(dish);
            return Ok("Dish updated");
        }


        [HttpDelete("order/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _adminService.DeleteOrder(orderId);
            return Ok("Order deleted");
        }
        [HttpPut("order/{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            await _adminService.UpdateOrderStatus(orderId, status);
            return Ok("Order status updated");
        }

        [HttpPut("customer/{customerId}/role")]

        public async Task<IActionResult> UpdateCustomerRole(int customerId, [FromQuery] string role)
        {
            // Hämtar kunden från tjänsten (för att få IdentityUserId)
            var customers = await _adminService.GetAllCustomers();
            var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null) return NotFound("Customer not found");

            var user = await _userManager.FindByIdAsync(customer.IdentityUserId);
            if (user == null) return NotFound("User not found");

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            await _userManager.AddToRoleAsync(user, role);

            await _adminService.UpdateCustomerRole(customerId, role);
            return Ok($"Customer role updated to {role}");
        }


    }
}
