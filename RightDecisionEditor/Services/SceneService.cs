using Microsoft.EntityFrameworkCore;
using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class SceneService(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    
    public async Task<Scene> PostScene (SceneRequestDto sceneRequest)
    {
        Scene scene = new(sceneRequest.GameId, sceneRequest.Title, sceneRequest.Text, [], sceneRequest.FirstScene);
        Game game = await _context.Games.FirstOrDefaultAsync(game => game.Id == sceneRequest.GameId) ?? throw new KeyNotFoundException($"Game with ID {sceneRequest.GameId} not Found");

        _context.Scenes.Add(scene);
        game.ScenesId.Add(scene.Id);

        await _context.SaveChangesAsync();

        return scene;
    }
}