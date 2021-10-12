using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cd_c_productsCategories.Models
{
    public class ProductsHasCategories
    {
        [Key]
        public int ProductsHasCategoriesId {get;set;}

        public int ProductId {get;set;}
        public Product Product {get;set;}

        public int CategoryId {get;set;}
        public Category Category {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}