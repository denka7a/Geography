using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Data.Models
{
    public class NatureObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string URL { get; set; }
        public int NatureTypeId { get; set; }
        public NatureType NatureType { get; set; }
    }
}
