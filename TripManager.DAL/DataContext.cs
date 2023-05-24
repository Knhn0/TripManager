using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TripManager.DAL.Models;


namespace TripManager.DAL
{

    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCategory>()
                .HasKey(uc => new { uc.UserId, uc.CategoryId });
            modelBuilder.Entity<UserCategory>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.UserCategories)
                .HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCategory>()
                .HasOne<Category>(uc => uc.Category)
                .WithMany(c => c.UserCategories)
                .HasForeignKey(uc => uc.CategoryId);
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