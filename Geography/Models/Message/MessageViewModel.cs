using System.ComponentModel.DataAnnotations;
using Geography.Data.Data.Constants;

namespace Geography.Models.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Message.WriterNameMaxLength)]
        [MinLength(DataConstants.Message.WriterNameMinLength)]
        public string Writer { get; set; }
        [Required]
        [MaxLength(DataConstants.Message.MessageMaxLength)]
        [MinLength(DataConstants.Message.MessageMinLength)]
        public string Text { get; set; }
    }
}
