using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpGet("get-customers")]
        public IActionResult GetAllCustomers()
        {
            // Logic to get all admins
            return Ok();
        }


        [HttpGet("get-regular-customers")]
        public IActionResult GetRegularCustomers()
        {
            // Logic to get all regular customers
            return Ok();
        }

        [HttpGet("get-premium-customers")]
        public IActionResult GetPremiumCustomers()
        {
            // Logic to get all premium customers
            return Ok();
        }

        [HttpPost("create-dish")]
        public IActionResult CreateDish(Dish dish)
        {
            // Logic to create a new dish
            return CreatedAtAction(dish.DishId.ToString(), dish);
        }

        [HttpPut("update-dish")]
        public IActionResult UpdateDish(Dish dish)
        {
            // Logic to update a dish
            return CreatedAtAction(dish.DishId.ToString(), dish);
        }


        [HttpDelete("delete-order")]
        public IActionResult DeleteOrder(int orderId)
        {
            // Logic to delete an order
            return Ok();
        }

        [HttpPut("update-customer-role")]
        public IActionResult UpdateCustomerRole(int customerId, string role)
        {
            // Logic to update a customer's role
            return Ok();
        }

        [HttpPut("update-order-status")]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
            // Logic to update an order's status
            return Ok();
        }

    }
}
