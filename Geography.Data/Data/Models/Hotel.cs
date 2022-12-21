using Geography.Data.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Data.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Hotel.NameMaxLength)]
        public string Name { get; set; }
        public int Stars { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        public bool IsRemove { get; set; }
        [Required]
        [MaxLength(DataConstants.Hotel.NatureNameMaxLength)]
        public string NatureName { get; set; }
        public int NatureId { get; set; }
        public NatureObject Nature { get; set; }
    }
}
