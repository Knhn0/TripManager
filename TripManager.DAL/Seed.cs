using TripManager.DAL.Models;

namespace TripManager.DAL;

public class Seed
{
    private readonly DataContext _context;

    public Seed(DataContext context)
    {
        _context = context;
    }

    public void SeedDataContext()
    {
        if (!_context.Categories.Any())
        {
            var categories = new List<Category>()
            {
                new Category() { Name = "Спортивный" },
                new Category() { Name = "Культурно-просветительный" },
                new Category() { Name = "Театрально-музыкальный" },
                new Category() { Name = "Семейный отдых" },
                new Category() { Name = "Гастротуризм" },
                new Category() { Name = "Туры научной направленности" }
            };
            
            _context.Categories.AddRange(categories);
            _context.SaveChanges();
        }
    }
}