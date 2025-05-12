using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos_Pizzeria.Data.Entities
{
    public class Order
    {
        [Key]
        
        public int OrderId { get; set; }
        [Required]
        [StringLength(500)]
        public string OrderDetails { get; set; }
        [Required]
        [StringLength(100)]
        public string Price { get; set; }

        [Required]
        [StringLength(100)]
        public string OrderStatus { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
