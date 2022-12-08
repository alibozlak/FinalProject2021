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

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("orders");

            modelBuilder.Entity<Order>().Property(order => order.OrderId).HasColumnName("order_id");
            modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Order>().Property(o => o.EmployeeId).HasColumnName("employee_id");
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasColumnName("order_date");
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("ship_city");
        }
    }
}
