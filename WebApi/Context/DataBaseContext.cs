using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Book> Books {  get; set; }
        public DbSet<Author> Authors { get; set;}
        public DbSet<User> Users { get; set; }
    }
}
