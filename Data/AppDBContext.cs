using Microsoft.EntityFrameworkCore;
using myFirstapp.Models;

namespace myFirstapp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> Options) : base(Options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
