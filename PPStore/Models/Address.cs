using System.ComponentModel.DataAnnotations;

namespace PPStore.Models
{
    public class Address : BaseModel
    {
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string Telephone { get; set; }
    }
}