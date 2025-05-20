using Tomasos.Domain.DTO;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Core.Interfaces
{
    public interface ICustomerService
    {

        Task<List<Customer>> GetCustomerData();
        Task LoginCustomer(Customer customer);
        Task UpdateCustomerData(Customer customer);
        Task<List<Order>> GetOrderList();
        Task CreateAccount(Customer customer);
        Task<string?> LoginCustomer(CustomerDTO.CustomerLoginDTO customer);
    }
}
