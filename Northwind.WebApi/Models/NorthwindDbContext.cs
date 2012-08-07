using System.Data.Entity;

namespace Northwind.WebApi.Models
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(): base("name=NorthwindCE")
        {
        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Order>().HasMany(o => o.OrderDetails)
//                                        .WithRequired(od => od.Order)
//                                        .HasForeignKey(ou => ou.OrderID);
//
//            base.OnModelCreating(modelBuilder);
//        }

        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }  
    }
}