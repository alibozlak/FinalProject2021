using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : DB tabloları ile proje classlarını bağlayan class
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=Northwind;Username=postgres;Password=postgre84,SQL43");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(order => order.OrderId).HasColumnName("order_id");
            modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Order>().Property(o => o.EmployeeId).HasColumnName("employee_id");
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasColumnName("order_date");
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("ship_city");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unit_price");
            modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("units_in_stock");

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(c => c.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasColumnName("category_name");

            modelBuilder.Entity<Customer>().ToTable("customers");
            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Customer>().Property(c => c.CompanyName).HasColumnName("campany_name");
            modelBuilder.Entity<Customer>().Property(c => c.ContactName).HasColumnName("contact_name");
            modelBuilder.Entity<Customer>().Property(c => c.City).HasColumnName("city");
        }
    }
}
