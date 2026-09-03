using Microsoft.EntityFrameworkCore;
// using RightDecisionPlayer.Models;

namespace RightDecisionPlayer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // public DbSet<Scene> Scenes { get; set; }
        // public DbSet<Choice> Choices { get; set; }
        // public DbSet<Game> Games { get; set; }
    }
}