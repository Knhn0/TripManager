using TripManager.DAL.Models;

namespace TripManager.DAL;

public class UserDomain : IUserDomain
{
    private readonly IDataContext dataContext;

    public UserDomain(IDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public User GetUsers(string email, string password)
    {
        var user = dataContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        return user;
    }

    public bool Registration(User user)
    {
        dataContext.Users.Add(user);
        int changes = dataContext.Save();
        return changes == 0 ? false : true;
    }
}