using MassTransit;
using Microsoft.EntityFrameworkCore;
using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class GameService(AppDbContext context, IPublishEndpoint endpoint)
{
    private readonly AppDbContext _context = context;
    private readonly IPublishEndpoint _endpoint = endpoint;
    
    public async Task<Game> PostGame (GameRequestDto gameRequest)
    {
        Game game = new(gameRequest.Title, gameRequest.Description, false);
        
        _context.Games.Add(game);

        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<Game> PublishGame (Guid gameId)
    {
        Game game = await _context.Games.FirstOrDefaultAsync(game => game.Id == gameId) ?? throw new KeyNotFoundException($"Game with ID {gameId} not Found");
        game.IsPublished = true;
    
        await _context.SaveChangesAsync();
        await _endpoint.Publish(game);

        return game;
    }
}