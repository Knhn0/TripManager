using TripManager.Service.Models;

namespace TripManager.Service.Interfaces;

public interface IUserLogic
{
        bool Register(User user);
        string Auth(User user);
}