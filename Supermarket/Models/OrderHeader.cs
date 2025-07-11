﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Supermarket.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? OrderStatus { get; set; } // Added OrderStatus
        public string? PaymentStatus { get; set; } // Added PaymentStatus

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Name { get; set; }

         // Added PostalCode
        public string? PostalCode { get; set; }
    }
}