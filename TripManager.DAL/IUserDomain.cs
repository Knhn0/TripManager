using TripManager.DAL.Models;
namespace TripManager.DAL
{
    public interface IUserDomain
    {
        bool Registration(User user);
        User GetUsers(string email, string password);
    }
}