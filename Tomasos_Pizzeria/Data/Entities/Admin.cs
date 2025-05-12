using System.ComponentModel.DataAnnotations;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(600)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }
    }
}
