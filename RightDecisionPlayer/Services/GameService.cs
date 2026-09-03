using Microsoft.EntityFrameworkCore;
using RightDecisionPlayer.Data;
using RightDecisionPlayer.DTOs;
using RightDecisionPlayer.Models;

namespace RightDecisionPlayer.Services;

public class GameService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<SceneResponseDto> GetFirstScene(Guid gameId)
    {
        Game game = await _context.Games.AsNoTracking().FirstOrDefaultAsync(games => games.Id == gameId) ?? throw new KeyNotFoundException($"Game with ID {gameId} not Found");
        Scene firstScene = game.Scenes.FirstOrDefault(scene => scene.FirstScene == true) ?? throw new KeyNotFoundException($"First scene not found");

        return new SceneResponseDto(
            firstScene.Title,
            firstScene.Text,
            [.. firstScene.Choices.Select(choice => new ChoiceResponseDto(
                choice.Id,
                choice.Text
            ))]
        );
    }

    public async Task<SceneResponseDto> GetScene(Guid gameId, Guid choiceId)
    {
        Game game = await _context.Games.AsNoTracking().FirstOrDefaultAsync(games => games.Id == gameId) ?? throw new KeyNotFoundException($"Game with ID {gameId} not Found");
        Choice choice = game.Scenes.SelectMany(scene => scene.Choices).FirstOrDefault(choice => choice.Id == choiceId) ?? throw new KeyNotFoundException($"Choice with Id {choiceId} not Found");
        Scene nextScene = game.Scenes.FirstOrDefault(scene => scene.Id == choice.NextSceneId) ?? throw new KeyNotFoundException($"Scene with Id {choice.NextSceneId} not Found");

        return new SceneResponseDto(
            nextScene.Title,
            nextScene.Text,
            [.. nextScene.Choices.Select(choice => new ChoiceResponseDto(
                choice.Id,
                choice.Text
            ))]
        );
    }
}