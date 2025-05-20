using Tomasos.Domain.DTO;
using Tomasos_Pizzeria.Core.Interfaces;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

namespace Tomasos_Pizzeria.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<Customer>> GetCustomerData()
        {
            return await _customerRepo.GetCustomerData();
        }

        public async Task LoginCustomer(Customer customer)
        {
            await _customerRepo.LoginCustomer(customer);
        }

        public async Task UpdateCustomerData(Customer customer)
        {
            await _customerRepo.UpdateCustomerData(customer);
        }

        public async Task<List<Order>> GetOrderList()
        {
            return await _customerRepo.GetOrderList();
        }

        public async Task CreateAccount(Customer customer)
        {
            await _customerRepo.CreateAccount(customer);
        }

        public Task<string?> LoginCustomer(CustomerDTO.CustomerLoginDTO customer)
        {
            throw new NotImplementedException();
        }
    }
    
}
