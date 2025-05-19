using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }



        public ICollection<Customer> Customers { get; set; } = new List<Customer>();



    }
}


