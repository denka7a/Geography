using System.ComponentModel.DataAnnotations;
using Geography.Data.Data.Constants;

namespace Geography.Models.Hotel
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Hotel.HotelNameMaxLength)]
        [MinLength(DataConstants.Hotel.HotelNameMinLength)]
        public string Name { get; set; }
        [Range(DataConstants.Hotel.HotelStarsMinLength, DataConstants.Hotel.HotelStarsMaxLength)]
        public int Stars { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        [MaxLength(DataConstants.Hotel.NatureNameMaxLength)]
        [MinLength(DataConstants.Hotel.NatureNameMinLength)]
        public string NatureName { get; set; }
        public bool IsRemove { get; set; }
        public int NatureId { get; set; }
    }
}
