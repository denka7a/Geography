using System.ComponentModel.DataAnnotations;

namespace Geography.Models.User
{
    public class UserViewModel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be above 0")]
        public decimal Balance { get; set; }
    }
}
