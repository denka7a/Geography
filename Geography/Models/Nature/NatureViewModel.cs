using System.ComponentModel.DataAnnotations;

namespace Geography.Models.Nature
{
    public class NatureViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        [MinLength(3)]
        public string Information { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string NatureType { get; set; }
    }
}
