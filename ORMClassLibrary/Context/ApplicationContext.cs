using Microsoft.EntityFrameworkCore;
using ORM.Domain.Models;

namespace ORMClassLibrary.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted(); //to delete the database
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ORMfundamentals;Trusted_Connection=True;");
        }
    }
}
