using System.ComponentModel.DataAnnotations;
using Geography.Data.Data.Constants;

namespace Geography.Models.Nature
{
    public class NatureViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Nature.ObjectNameMaxLength)]
        [MinLength(DataConstants.Nature.ObjectNameMinLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(DataConstants.Nature.InformationMaxLength)]
        [MinLength(DataConstants.Nature.InformationMinLength)]
        public string Information { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        [MaxLength(DataConstants.Nature.TypeMaxLength)]
        [MinLength(DataConstants.Nature.TypeMinLength)]
        public string NatureType { get; set; }
    }
}
