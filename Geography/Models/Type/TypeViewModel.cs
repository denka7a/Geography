using Geography.Data.Data.Models;
using Geography.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Geography.Models.Type
{
    public class TypeViewModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Type { get; set; }
        public GeographyUser? User { get; set; }
    }
}
