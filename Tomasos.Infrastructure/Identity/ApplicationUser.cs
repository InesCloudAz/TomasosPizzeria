using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int BonusPoints { get; set; }

        [NotMapped]
        public object Address { get; set; }
    }
}
