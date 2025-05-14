using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

        
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Ingredients> Ingredients { get; set; } = new List<Ingredients>();






    }
}
