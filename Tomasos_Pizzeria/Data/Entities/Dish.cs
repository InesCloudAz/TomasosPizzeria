using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        [StringLength(600)]
        public string DishName { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Price { get; set; }
        [Required]
        [StringLength(2000)]
        public string IngredientsList { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public DishCategory DishCategory { get; set; }



    }
}
