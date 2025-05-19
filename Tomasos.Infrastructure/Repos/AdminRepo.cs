using Microsoft.EntityFrameworkCore;
using Tomasos.Infrastructure;
using Tomasos_Pizzeria.Data.Entities;
using Tomasos_Pizzeria.Data.Interfaces;

namespace Tomasos_Pizzeria.Data.Repos
{
    public class AdminRepo : IAdminRepo
    {

        private readonly TomasosPizzeriaContext _context;

        public AdminRepo(TomasosPizzeriaContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetRegularCustomers()
        {
            return await _context.Customers
                .Where(c => c.Role == "Regular")
                .ToListAsync();

        }

        public async Task<List<Customer>> GetPremiumCustomers()
        {
            return await _context.Customers
                .Where(c => c.Role == "Premium")
                .ToListAsync();


        }

        public async Task CreateDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDish(Dish dish)
        {

            var existingDish = await _context.Dishes.FindAsync(dish.DishId);
            if (existingDish != null)
            {
                existingDish.DishName = dish.DishName;
                existingDish.Description = dish.Description;
                existingDish.Price = dish.Price;
                existingDish.IngredientsList = dish.IngredientsList;
                await _context.SaveChangesAsync();
            }


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

        public async Task UpdateCustomerRole(int customerId, string role)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.Role = role;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.OrderStatus = status;
                await _context.SaveChangesAsync();
            }
        }

        
    }
    }
