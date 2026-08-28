using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class SceneService(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    
    public async Task<Scene> PostScene (SceneRequestDto sceneRequest)
    {
        Scene scene = new(sceneRequest.Title, sceneRequest.Text, []);
        
        _context.Scenes.Add(scene);

        await _context.SaveChangesAsync();

        return scene;
    }
}