using Geography.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Models
{
    public class GeographyUser : IdentityUser
    {
        public decimal Balance { get; set; }
        public ICollection<NatureType> NatureTypes { get; set; }
        public ICollection<UserSouvenir> UserSouvenirs { get; set; }
    }
}
