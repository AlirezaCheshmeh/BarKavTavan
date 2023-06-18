
using AdminBarKavTavan.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminBarKavTavan.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) :base(option) 
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<blogs> Blog { get; set; }
        
    }
}
