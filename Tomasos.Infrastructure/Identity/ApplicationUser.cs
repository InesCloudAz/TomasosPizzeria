using Microsoft.AspNetCore.Identity;

namespace Tomasos.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public int BonusPoints { get; set; } = 0;
    }
}
