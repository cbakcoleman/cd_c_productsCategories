using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cd_c_productsCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}

        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Name: ")]
        public string ProductName {get;set;}

        [Required(ErrorMessage = "Product description is required.")]
        [Display(Name = "Description: ")]
        public string Description{get;set;}

        [Required(ErrorMessage = "Product price is required.")]
        [Display(Name = "Price: ")]
        public decimal Price {get;set;}

        public List<ProductsHasCategories> Categories {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}