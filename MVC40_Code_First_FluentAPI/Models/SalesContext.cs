using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MVC40_Code_First_FluentAPI.Models
{

    /// <summary>
    /// The DbContecxt class, this is used to Create Database by reading Connection string from Web.Config file 
    /// and create tables in it  by executing the OnModelCreating method where mapping and constraints are defined.
    /// </summary>
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SalesContext()
            :base("name=SalesConnectionString")
        {

        }

        /// <summary>
        /// The below Method is used to define the Maping
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Mapping for the Customer Table
            //S1: Primary Key for the Customer Table
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            //S2: The Identity Key for the CustomerId
            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //S3: The Max lenght for the CustomerName (80),Address(100), MobileNo(14),PhoneNo(20),City(40),District(40),State(20)
            modelBuilder.Entity<Customer>().Property(c => c.CustomerName).HasMaxLength(80);
            modelBuilder.Entity<Customer>().Property(c => c.Address).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.MobileNo).HasMaxLength(14);
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNo).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(c => c.City).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(c => c.District).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(c => c.State).HasMaxLength(20);

            //Mapping for the Order Table
            
            //S1: Primary Key for the Order Table
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            //S2: The OrderId is Indentity
            modelBuilder.Entity<Order>().Property(o => o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //S2: Max Lenght for the OrderedItem  as 50
            modelBuilder.Entity<Order>().Property(o => o.OrderedItem).HasMaxLength(50);
            //S3: Foreign Key for the Order Table fp the CustomerId
            modelBuilder.Entity<Order>().HasRequired(c => c.Customer).WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId);

            //The Cascade Delete from Customer to Orders
            modelBuilder.Entity<Order>()
                .HasRequired(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerId)
                .WillCascadeOnDelete(true);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}