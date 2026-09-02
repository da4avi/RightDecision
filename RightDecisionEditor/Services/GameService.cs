using Microsoft.EntityFrameworkCore;
using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class GameService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<Game> PostGame(GameRequestDto gameRequest)
    {
        Game game = new(gameRequest.Title, gameRequest.Description, []);

        _context.Games.Add(game);

        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<SceneResponseDto> GetFirstScene(Guid gameId)
    {
        Scene firstScene = await _context.Scenes.FirstOrDefaultAsync(scene => scene.GameId == gameId && scene.FirstScene == true) ?? throw new KeyNotFoundException($"Game with ID {gameId} not Found");

        return new SceneResponseDto(
            firstScene.Title,
            firstScene.Text,
            await GroupChoicesByScene(firstScene)
        );
    }

    public async Task<SceneResponseDto> GetScene(Guid choiceId)
    {
        Choice choice = await _context.Choices.FirstOrDefaultAsync(choice => choice.Id == choiceId) ?? throw new KeyNotFoundException($"Choice with ID {choiceId} not Found");
        Scene scene = await _context.Scenes.FirstOrDefaultAsync(scene => scene.Id == choice.NextSceneId) ?? throw new KeyNotFoundException($"Scene with ID {choice.NextSceneId} not Found");

        return new SceneResponseDto(
            scene.Title,
            scene.Text,
            await GroupChoicesByScene(scene)
        );
    }

    public async Task<List<ChoiceResponseDto>> GroupChoicesByScene(Scene scene)
    {
        return await _context.Choices.Where(choice => scene.ChoicesId.Contains(choice.Id)).
        Select(choice => new ChoiceResponseDto(
            choice.Id,
            choice.Text
        )).ToListAsync();
    }
}