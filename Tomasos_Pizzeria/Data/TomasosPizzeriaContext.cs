using Microsoft.EntityFrameworkCore;
using Tomasos_Pizzeria.Data.Entities;

namespace Tomasos_Pizzeria.Data
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Dishes)
                .WithMany(d => d.Orders)
                .UsingEntity(j => j.ToTable("OrderDishes"));

            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .UsingEntity(j => j.ToTable("DishIngredients"));
        }

    }
}
