using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cd_c_productsCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}


        [Required(ErrorMessage = "Category name is required.")]
        [Display(Name = "Name: ")]
        public string CategoryName {get;set;}

        public List<ProductsHasCategories> Products {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}