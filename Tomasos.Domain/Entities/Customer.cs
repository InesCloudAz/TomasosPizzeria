using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Tomasos_Pizzeria.Data.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string ApplicationUserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone { get; set; }

        [Required]
        public int BonusPoints { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }
        public ICollection<UserType> UserTypes { get; set; } = new List<UserType>();

        [NotMapped]
        public object UserType { get; set; }


        //[Required]
        //public string IdentityUserId { get; set; }

        //[ForeignKey("IdentityUserId")]
        //public ApplicationUser IdentityUser { get; set; }








    }
}
