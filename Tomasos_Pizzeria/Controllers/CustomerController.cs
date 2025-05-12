using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpPost("login")]
        public IActionResult LoginCustomer(Customer customer)
        {
            // Logic to create a new customer
            return CreatedAtAction(nameof(GetCustomerData), new { id = customer.CustomerId }, customer);
        }

        [HttpGet("get-data")]
        public IActionResult GetCustomerData()
        {
            // Logic to get all customers
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateCustomerData(Customer customer)
        {
            // Logic to add a new customer
            return CreatedAtAction(nameof(GetCustomerData), new { id = customer.CustomerId }, customer);
        }

        [HttpGet]
        public IActionResult GetOrderList()
        {
            // Logic to get all orders
            return Ok();
        }

        [HttpPost("create-account")]
        public IActionResult CreateAccount(Order order)
        {

            // Logic to create a new account
            return CreatedAtAction(nameof(GetOrderList), new { id = order.OrderId }, order);

        }
    }
}
