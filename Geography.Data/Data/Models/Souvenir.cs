using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Models
{
    public class Souvenir
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Url]
        [Required]
        public string URL { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public ICollection<UserSouvenir> UserSouvenirs { get; set; }
    }
}
