using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tomasos.Domain.Entities;

namespace Tomasos.Infrastructure.Identity
{
    public class ApplicationUserContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserContext(DbContextOptions options) : base(options)
        {
        }

        //protected ApplicationUserContext()
        //{
        //}
    }
}
