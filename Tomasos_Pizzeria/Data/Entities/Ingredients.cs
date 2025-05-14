using System.ComponentModel.DataAnnotations;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class Ingredients
    {

        [Key]
        public int IngredientsId { get; set; }
        [Required]
        [StringLength(1000)]
        public string IngredientsList { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

       public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
        



    }
}
