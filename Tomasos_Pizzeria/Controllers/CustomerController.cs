using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomasos_Pizzeria.Core.Interfaces;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

namespace Tomasos_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly  ICustomerService _customerService;
        private readonly ICustomerRepo _customerRepo;

        [HttpPost("login")]
        public async Task <IActionResult> LoginCustomer(Customer customer)
        {
            
            return CreatedAtAction(nameof(GetCustomerData), new { id = customer.CustomerId }, customer);
        }

        [HttpGet("get-data")]
        public async Task <IActionResult> GetCustomerData()
        {

            return Ok();
        }

        [HttpPut("update")]
        public async Task <IActionResult> UpdateCustomerData(Customer customer)
        {
            // Logic to add a new customer
            return CreatedAtAction(nameof(GetCustomerData), new { id = customer.CustomerId }, customer);
        }

        [HttpGet("get-order-list")]
        public async Task <IActionResult> GetOrderList()
        {
            // Logic to get all orders
            return Ok();
        }

        [HttpPost("create-account")]
        public async Task <IActionResult> CreateAccount(Order order)
        {

            // Logic to create a new account
            return CreatedAtAction(nameof(GetOrderList), new { id = order.OrderId }, order);

        }
    }
}
