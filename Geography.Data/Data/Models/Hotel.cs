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
        [MaxLength(40)]
        public string Name { get; set; }
        public int Stars { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        public bool IsRemove { get; set; }
        [Required]
        [MinLength(3)]
        public string NatureName { get; set; }
        public int NatureId { get; set; }
        public NatureObject Nature { get; set; }
    }
}
