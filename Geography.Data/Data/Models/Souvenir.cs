using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Models
{
    public class Souvenir
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public decimal Price { get; set; }
        public ICollection<UserSouvenir> UserSouvenirs { get; set; }
    }
}
