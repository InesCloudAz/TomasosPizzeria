using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos.Infrastructure.Extensions
{
    public static class OrderExtensions
    {

        public static decimal CalculateTotalPrice(this Order order)
        {
            return order.Dishes.Sum(dish => dish.Price); 
        }


        public static decimal ApplyDiscount(this Order order)
        {
            decimal total = order.CalculateTotalPrice();
            if (order.Dishes.Count >= 3)
            {
                return total * 0.8m; // 20% rabatt
            }
            return total;
        }

        public static List<Customer> GetCustomersByRole(this List<Customer> customers, string role)
        {
            return customers.Where(c => c.Role == role).ToList();
        }
    }
}

