using Microsoft.AspNetCore.Identity;
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
            //var customer = await _adminRepo.GetCustomerById(customerId);
            //if (customer == null) throw new Exception("Customer not found");

            //var user = await _userManager.FindByIdAsync(customer.IdentityUserId);
            //if (user == null) throw new Exception("User not found");

            //var currentRoles = await _userManager.GetRolesAsync(user);
            //await _userManager.RemoveFromRolesAsync(user, currentRoles);

            //if (!await _roleManager.RoleExistsAsync(role))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(role));
            //}

            //await _userManager.AddToRoleAsync(user, role);
            //customer.Role = role;
            //await _adminRepo.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            await _adminRepo.UpdateOrderStatus(orderId, status);
        }


    }
}
