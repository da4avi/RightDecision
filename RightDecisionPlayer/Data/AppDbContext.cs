using Microsoft.EntityFrameworkCore;
using RightDecisionPlayer.Models;
namespace RightDecisionPlayer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(game => game.Id);
                entity.OwnsMany(game => game.Scenes, sceneBuilder =>
                {
                    sceneBuilder.ToJson();
                    sceneBuilder.OwnsMany(scene => scene.Choices);
                });
            });
        }
    }
}