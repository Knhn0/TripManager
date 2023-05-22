using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TripManager.DAL.Models;

namespace TripManager.DAL;

public interface IDataContext
{
    public DbSet<User> Users { get; set; }
    public DatabaseFacade GetDatabase();
    public int Save();
}