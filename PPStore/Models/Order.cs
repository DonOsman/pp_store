using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PPStore.Models
{
    public class Order : BaseModel
    {
        [Required] public PPUser PpUser { get; set; }
        [Required] public ICollection<OrderPizza> Pizzas { get; set; }
        [Required] public DateTime OrderTime { get; set; }
    }
}