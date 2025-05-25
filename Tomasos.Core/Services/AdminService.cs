using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tomasos.Core.Interfaces;
using Tomasos.Domain.DTO;
using Tomasos.Infrastructure.Data;
using Tomasos.Infrastructure.Identity;
using Tomasos_Pizzeria.Data.Entities;

public class AdminService : IAdminService
    {

    private readonly TomasosPizzeriaContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminService(
   TomasosPizzeriaContext context,
   UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }



    public async Task CreateDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerDTO>> GetAllCustomers()
        {
        return await _context.Customers
     .Select(c => new CustomerDTO
     {
         Username = c.UserName,
         Email = c.Email,
         PhoneNumber = c.Phone,
         BonusPoints = c.BonusPoints,
         Address = c.Role
     }).ToListAsync();
    }

        public async Task<List<Customer>> GetPremiumCustomers()
        {
        var usersInRole = await _userManager.GetUsersInRoleAsync("PremiumUser");
        return _context.Customers.Where(c => usersInRole.Any(u => u.Id == c.ApplicationUserId)).ToList();
    }

        public async Task<List<Customer>> GetRegularCustomers()
        {
        var usersInRole = await _userManager.GetUsersInRoleAsync("RegularUser");
        return _context.Customers.Where(c => usersInRole.Any(u => u.Id == c.ApplicationUserId)).ToList();
    }

        public async Task UpdateCustomerRole(int customerId, string role)
        {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer == null) return;

        var user = await _userManager.FindByIdAsync(customer.ApplicationUserId); // du behöver kanske koppla Customer till ApplicationUser

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, role);
        }
    }

        public async Task UpdateDish(Dish dish)
        {
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }

