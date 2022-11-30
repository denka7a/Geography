using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Data.Models
{
    public class NatureObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(300)]
        [Required]
        public string Information { get; set; }
        [Url]
        [Required]
        public string URL { get; set; }
        public int NatureTypeId { get; set; }
        public NatureType NatureType { get; set; }
    }
}
