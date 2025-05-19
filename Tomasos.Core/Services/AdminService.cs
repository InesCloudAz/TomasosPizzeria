using Tomasos.Core.Interfaces;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

namespace Tomasos_Pizzeria.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo _adminRepo;
        public AdminService(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _adminRepo.GetAllCustomers();
        }

        public async Task<List<Customer>> GetRegularCustomers()
        {
            return await _adminRepo.GetRegularCustomers();
        }

        public async Task<List<Customer>> GetPremiumCustomers()
        {
            return await _adminRepo.GetPremiumCustomers();
        }

        public async Task CreateDish(Dish dish)
        {
            await _adminRepo.CreateDish(dish);
        }

        public async Task UpdateDish(Dish dish)
        {
            await _adminRepo.UpdateDish(dish);
        }

        public async Task DeleteOrder(int orderId)
        {
            await _adminRepo.DeleteOrder(orderId);
        }

        public async Task UpdateCustomerRole(int customerId, string role)
        {
            await _adminRepo.UpdateCustomerRole(customerId, role);
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            await _adminRepo.UpdateOrderStatus(orderId, status);
        }


    }
}
