using TripManager.Domain.Entities;

namespace TripManager.Service.Logic;

public interface IUserLogic
{
        bool Register(User user);
        string Auth(User user);
}