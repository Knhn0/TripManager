using System.ComponentModel.DataAnnotations;

namespace TripManager.DAL.Models;

public class Category
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserCategory> UserCategories { get; set; }
}