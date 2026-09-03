using Microsoft.EntityFrameworkCore;
using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class ChoiceService(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    
    public async Task<Choice> PostChoice (ChoiceRequestDto choiceRequest)
    {
        Choice choice = new(choiceRequest.Text, choiceRequest.SceneId, choiceRequest.NextSceneId);
        Scene scene = await _context.Scenes.FirstOrDefaultAsync(scene => scene.Id == choiceRequest.SceneId) ?? throw new KeyNotFoundException($"Scene with ID {choiceRequest.SceneId} not Found");
        
        _context.Choices.Add(choice);
        //update the scene choices
        scene.Choices.Add(choice);

        await _context.SaveChangesAsync();

        return choice;
    }
}