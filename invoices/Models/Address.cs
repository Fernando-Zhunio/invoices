﻿using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Address: BaseEntity
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public string Street { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [Required]
        public string Direction { get; set; }
        public string Reference { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
