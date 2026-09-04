using MassTransit;
using Microsoft.EntityFrameworkCore;
using RightDecision.Contracts;
using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.DTOs.Published;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class GameService(AppDbContext context, IPublishEndpoint endpoint)
{
    private readonly AppDbContext _context = context;
    private readonly IPublishEndpoint _endpoint = endpoint;

    public async Task<Game> PostGame(GameRequestDto gameRequest)
    {
        Game game = new(gameRequest.Title, gameRequest.Description, false);

        _context.Games.Add(game);

        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<Game> PublishGame(Guid gameId)
    {
        //busca o jogo e popula scenes e choices
        Game game = await _context.Games
        .Include(games => games.Scenes)
            .ThenInclude(scenes => scenes.Choices)
        .FirstOrDefaultAsync(game => game.Id == gameId) ?? throw new KeyNotFoundException($"Game with ID {gameId} not Found");
        game.IsPublished = true;

        //atualiza o estado do ispublished
        await _context.SaveChangesAsync();
        
        //publica com o contrato no rabbitmq
        await _endpoint.Publish(
            new GamePublishedEvent(
                game.Id,
                game.Title,
                game.Description,
                [.. game.Scenes.Select(scene => new ScenePublishedDto(
                    scene.Id,
                    scene.Title,
                    scene.Text,
                    [.. scene.Choices.Select(choice => new ChoicePublishedDto(
                        choice.Id,
                        choice.Text,
                        choice.NextSceneId
                    ))],
                    scene.FirstScene
                ))]
            )
        );

        return game;
    }
}