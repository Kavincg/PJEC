﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Supermarket.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(10, 1000, ErrorMessage = "Price must between 10 and 1000")]
        public int price { get; set; }
        [ValidateNever]
        public string imgURL { get; set; }

        //  public int? Discount {  get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Product image")]
        public IFormFile ProductImage { get; set; }

    }
}
