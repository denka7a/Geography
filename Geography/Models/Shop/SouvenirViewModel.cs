using Geography.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Geography.Models.Shop
{
    public class SouvenirViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }
        [Url]
        [Required]
        public string URL { get; set; }
        public decimal Price { get; set; }
    }
}
