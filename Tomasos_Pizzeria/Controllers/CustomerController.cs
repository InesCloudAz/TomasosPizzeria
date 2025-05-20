using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomasos_Pizzeria.Core.Interfaces;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;
using static Tomasos.Domain.DTO.CustomerDTO;

namespace Tomasos_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly  ICustomerService _customerService;
        



        [HttpPost]
        [AllowAnonymous]
        [Route("api/login")]
        public async Task <IActionResult> LoginCustomer(CustomerLoginDTO customer)
        {

            var token = await _customerService.LoginCustomer(customer);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        [HttpGet("get-data")]
        [Authorize]
        public async Task <IActionResult> GetCustomerData()
        {
            var customerData = await _customerService.GetCustomerData();
            if (customerData == null)
            {
                return NotFound();
            }
            return Ok(customerData);
        


           
        }

        [HttpPut("update")]
        public async Task <IActionResult> UpdateCustomerData(Customer customer)
        {
            
            return CreatedAtAction(nameof(GetCustomerData), new { id = customer.CustomerId }, customer);
        }

        [HttpGet("get-order-list")]
        public async Task <IActionResult> GetOrderList()
        {
            
            return Ok();
        }

        [HttpPost("create-account")]
        public async Task <IActionResult> CreateAccount(Order order)
        {

          
            return CreatedAtAction(nameof(GetOrderList), new { id = order.OrderId }, order);

        }
    }
}
