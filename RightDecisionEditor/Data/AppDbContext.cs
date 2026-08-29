using Microsoft.EntityFrameworkCore;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Choice> Choices { get; set; }
    }
}