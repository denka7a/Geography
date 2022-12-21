using Geography.Data.Data.Models;
using Geography.Data.Models;
using System.ComponentModel.DataAnnotations;
using Geography.Data.Data.Constants;

namespace Geography.Models.Type
{
    public class TypeViewModel
    {
        [Required]
        [MaxLength(DataConstants.Nature.TypeMaxLength)]
        [MinLength(DataConstants.Nature.TypeMinLength)]
        public string Type { get; set; }
        public GeographyUser? User { get; set; }
    }
}
