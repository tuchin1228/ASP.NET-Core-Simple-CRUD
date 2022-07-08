using Microsoft.EntityFrameworkCore;
using RelationTest.Models;

namespace RelationTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<CheeseCategory> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
