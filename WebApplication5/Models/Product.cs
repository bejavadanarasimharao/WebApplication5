using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Product
    {
        [Required]
        [Range(1, 50, ErrorMessage = "please enter value between 1 to 50 range")]
        public int? ProductId { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "please max 7 characters")]
        public string ProductName { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "please max 7 characters")]
        public string ProductDescription { get; set; }
        public int CurrentPrice { get; set; }
    }
}