using System.ComponentModel.DataAnnotations;

namespace PPStore.Models
{
    public class Pizza : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
    }
}