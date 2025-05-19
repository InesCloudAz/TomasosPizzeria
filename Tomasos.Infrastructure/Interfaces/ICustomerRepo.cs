using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Data.Interfaces
{
    public interface ICustomerRepo
    {
        Task <List<Customer>> GetCustomerData();
        Task LoginCustomer(Customer customer);
        Task UpdateCustomerData(Customer customer);
        Task <List<Order>> GetOrderList();
        Task CreateAccount(Customer customer);

    }
}
