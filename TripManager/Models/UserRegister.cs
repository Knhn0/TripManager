namespace TripManager.Models;

public class UserRegister
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }   
    
    public int? UserType { get; set; }
}