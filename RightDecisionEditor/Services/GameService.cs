using RightDecisionEditor.Data;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Models;

namespace RightDecisionEditor.Services;

public class GameService(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    
    public async Task<Game> PostGame (GameRequestDto gameRequest)
    {
        Game game = new(gameRequest.Title, gameRequest.Description, []);
        
        _context.Games.Add(game);

        await _context.SaveChangesAsync();

        return game;
    }
}