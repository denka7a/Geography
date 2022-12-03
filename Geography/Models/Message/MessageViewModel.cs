using System.ComponentModel.DataAnnotations;

namespace Geography.Models.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Writer { get; set; }
        [Required]
        [MaxLength(300)]
        [MinLength(3)]
        public string Text { get; set; }
    }
}
