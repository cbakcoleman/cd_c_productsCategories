using Microsoft.EntityFrameworkCore;

namespace cd_c_productsCategories.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<ProductsHasCategories> ProductsHasCategories {get;set;}
    }
}