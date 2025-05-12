using Microsoft.EntityFrameworkCore;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

namespace Tomasos_Pizzeria.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly TomasosPizzeriaContext _context;
        public CustomerRepo(TomasosPizzeriaContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomerData()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task LoginCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == customer.Email && c.Password == customer.Password);
            if (existingCustomer != null)
            {
                // Customer found, perform login logic here
            }
            else
            {
                // Customer not found, handle login failure
            }
        }

        public async Task UpdateCustomerData(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.UserName = customer.UserName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Password = customer.Password;
                existingCustomer.Phone = customer.Phone;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Order>> GetOrderList()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task CreateAccount(Customer customer)
        {

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();


        }

    }
}
