using Geography.Data.Data.Constants;
using Geography.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Geography.Data.Models
{
    public class GeographyUser : IdentityUser
    {
        [Required]
        [MaxLength(DataConstants.User.FullNameMaxLength)]
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public ICollection<NatureType> NatureTypes { get; set; }
        public ICollection<UserSouvenir> UserSouvenirs { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
