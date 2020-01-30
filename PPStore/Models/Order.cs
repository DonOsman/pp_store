using System.ComponentModel.DataAnnotations;

namespace PPStore.Models
{
    public class Order : BaseModel
    {
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public Pizza Pizza { get; set; }
        [Required]
        public int PizzaCount { get; set; }
    }
}