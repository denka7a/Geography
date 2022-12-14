using Geography.Data.Data.Constants;
using Geography.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Message.WriterNameMaxLength)]
        public string Writer { get; set; }
        [Required]
        [MaxLength(DataConstants.Message.MessageMaxLength)]
        public string Text { get; set; }
        public string geographyUserId { get; set; }
        public GeographyUser geographyUser { get; set; }
    }
}
