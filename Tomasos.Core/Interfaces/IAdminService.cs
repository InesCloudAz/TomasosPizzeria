using Tomasos.Domain.DTO;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos.Core.Interfaces
{
    public interface IAdminService
    {
        Task<List<CustomerDTO>> GetAllCustomers();
        Task<List<Customer>> GetRegularCustomers();
        Task<List<Customer>> GetPremiumCustomers();
        Task CreateDish(Dish dish);
        Task UpdateDish(Dish dish);
        Task DeleteOrder(int orderId);
        Task UpdateCustomerRole(int customerId, string role);
        Task UpdateOrderStatus(int orderId, string status);



    }
}
