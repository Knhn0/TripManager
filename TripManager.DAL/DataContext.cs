using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TripManager.DAL.Models;


namespace TripManager.DAL
{

    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DatabaseFacade GetDatabase()
        {
            return Database;
        }

        public int Save()
        {
            int changes;
            try
            {
                changes = SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return changes;
        }
    }
}