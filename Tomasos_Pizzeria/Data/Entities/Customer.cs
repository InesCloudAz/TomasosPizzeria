using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

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
        [StringLength(100)]
        public string Role { get; set; }

        public int UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }



    }
}
