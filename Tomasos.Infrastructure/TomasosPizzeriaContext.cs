using Tomasos_Pizzeria.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Tomasos.Infrastructure
{
    public class TomasosPizzeriaContext : DbContext
    {
        public TomasosPizzeriaContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }


       

    }
}
