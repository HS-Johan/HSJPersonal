using HSJPersonal.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HSJPersonal.Data
{
    public class HSJPersonalContext : DbContext
    {
        public HSJPersonalContext(DbContextOptions<HSJPersonalContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set;} = default!; 

        public DbSet<Product> products { get; set;} = default!;

        public DbSet<Blog> Blog { get; set;} = default!;

        public DbSet<Admin> Admin { get; set;} = default!;

        public DbSet<Social> Social { get; set;} = default!;
    }
}
