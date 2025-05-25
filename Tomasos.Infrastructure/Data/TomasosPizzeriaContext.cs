using Tomasos_Pizzeria.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Tomasos.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Tomasos.Infrastructure.Data
{
    public class TomasosPizzeriaContext : IdentityDbContext<ApplicationUser>
    {
        public TomasosPizzeriaContext(DbContextOptions<TomasosPizzeriaContext> options) : base(options)
        {
        }

       

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }


       

    }
}
