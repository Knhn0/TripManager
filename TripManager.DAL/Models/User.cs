using System.ComponentModel.DataAnnotations;

namespace TripManager.DAL.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    
    public int? UserType { get; set; }
}