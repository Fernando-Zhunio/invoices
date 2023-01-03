﻿using System.ComponentModel.DataAnnotations;

namespace invoices.Models
{
    public class TypeAttachment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
