using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Models
{
    public class UserSouvenir
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public GeographyUser GeographyUser { get; set; }

        public int SouvenirId { get; set; }
        public Souvenir Souvenir { get; set; }
    }
}
