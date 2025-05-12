using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Data.Interfaces
{
    public interface IAdminRepo
    {
       Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetRegularCustomers();
        Task<List<Customer>> GetPremiumCustomers();
        Task CreateDish(Dish dish);
        Task UpdateDish(Dish dish);
        Task DeleteOrder(int orderId);
        Task UpdateCustomerRole(int customerId, string role);
        Task UpdateOrderStatus(int orderId, string status);
       
    }
}
