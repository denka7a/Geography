using System.ComponentModel.DataAnnotations;

namespace Geography.Models.User
{
    public class UserViewModel
    {
        public string? FullName { get; set; }
        [Range(0d, 10000d)]
        public decimal Balance { get; set; }
    }
}
