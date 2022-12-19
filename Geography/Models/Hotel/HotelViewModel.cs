using System.ComponentModel.DataAnnotations;

namespace Geography.Models.Hotel
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(1, 5)]
        public int Stars { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        public string NatureName { get; set; }
        public bool IsRemove { get; set; }
        public int NatureId { get; set; }
    }
}
