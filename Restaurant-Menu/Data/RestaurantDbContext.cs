using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Menu.Models;

namespace Restaurant_Menu.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Allergen> Allergens { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;
        public DbSet<ProductAllergen> ProductAllergens { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<MenuProduct> MenuProducts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderMenu> OrderMenus { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<ConfigSettings> ConfigSettings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=1q2w3e;Database=restaurant-menu;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAllergen>().HasKey(pa => new { pa.ProductId, pa.AllergenId });
            modelBuilder.Entity<MenuProduct>().HasKey(mp => new { mp.MenuId, mp.ProductId });
            modelBuilder.Entity<OrderMenu>().HasKey(om => new { om.OrderId, om.MenuId });
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<ProductImage>().HasKey(pi => pi.ImageId);

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Allergen>().ToTable("allergens");
            modelBuilder.Entity<ProductImage>().ToTable("productimages");
            modelBuilder.Entity<ProductAllergen>().ToTable("productallergens");
            modelBuilder.Entity<Menu>().ToTable("menus");
            modelBuilder.Entity<MenuProduct>().ToTable("menuproducts");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderMenu>().ToTable("ordermenus");
            modelBuilder.Entity<OrderProduct>().ToTable("orderproducts");
            modelBuilder.Entity<ConfigSettings>().ToTable("configsettings");



            modelBuilder.Entity<ConfigSettings>().HasData(
                new ConfigSettings { Id = 1 }
            );
        }
    }
}
