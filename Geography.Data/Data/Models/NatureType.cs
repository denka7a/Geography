﻿using Geography.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Data.Models
{
    public class NatureType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        public GeographyUser User { get; set; }
        public string UserId { get; set; }
        public ICollection<NatureObject> NatureObjects { get; set; }
    }
}
