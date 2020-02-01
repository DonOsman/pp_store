using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPStore.Models
{
    public class OrderPizza
    {
        [Required] public int OrderId { get; set; }
        [Required] public int PizzaId { get; set; }
        [Required] public Order Order { get; set; }
        [Required] public Pizza Pizza { get; set; }
        [Required] public int Amount { get; set; }
        [Required] public decimal UnitCost { get; set; }

        [NotMapped] public decimal Cost => Amount * UnitCost;
    }
}