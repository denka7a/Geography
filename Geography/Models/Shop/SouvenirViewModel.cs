using Geography.Data.Models;
using System.ComponentModel.DataAnnotations;
using Geography.Data.Data.Constants;

namespace Geography.Models.Shop
{
    public class SouvenirViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Souvenir.SouvenirNameMaxLength)]
        [MinLength(DataConstants.Souvenir.SouvenirNameMinLength)]
        public string Name { get; set; }
        [Url]
        [Required]
        public string URL { get; set; }
        public decimal Price { get; set; }
    }
}
