using System.ComponentModel.DataAnnotations;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class DishCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(600)]
        public string CategoryName { get; set; }
    }
}
