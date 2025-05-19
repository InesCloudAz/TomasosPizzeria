using Microsoft.AspNetCore.Mvc;
using Tomasos.Core.Interfaces;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

namespace Tomasos_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAdminRepo _adminRepo;

        [HttpPost("login")]
        //public async Task <IActionResult> LoginAdmin (Admin admin)
        //{
        //     return 
        //}

        [HttpGet("get-customers")]
        public IActionResult GetAllCustomers()
        {
            return Ok();
        }


        [HttpGet("get-regular-customers")]
        public IActionResult GetRegularCustomers()
        {
          
            return Ok();
        }

        [HttpGet("get-premium-customers")]
        public IActionResult GetPremiumCustomers()
        {
            
            return Ok();
        }

        [HttpPost("create-dish")]
        public IActionResult CreateDish(Dish dish)
        {
            
            return CreatedAtAction(dish.DishId.ToString(), dish);
        }

        [HttpPut("update-dish")]
        public IActionResult UpdateDish(Dish dish)
        {
            
            return CreatedAtAction(dish.DishId.ToString(), dish);
        }


        [HttpDelete("delete-order")]
        public IActionResult DeleteOrder(int orderId)
        {
            
            return Ok();
        }

        [HttpPut("update-customer-role")]
        public IActionResult UpdateCustomerRole(int customerId, string role)
        {
           
            return Ok();
        }

        [HttpPut("update-order-status")]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
          
            return Ok();
        }

    }
}
