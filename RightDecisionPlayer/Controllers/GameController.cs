using Microsoft.AspNetCore.Mvc;
using RightDecisionPlayer.Services;

namespace RightDecisionPlayer.Controllers;

[ApiController]
[Route("api/game")]
public class GameController(GameService gameService) : ControllerBase
{
    private readonly GameService _gameService = gameService;

    [HttpGet("firstScene")]
    public async Task<IActionResult> GetFirstScene(Guid gameId)
    {
        var result = await _gameService.GetFirstScene(gameId);

        return Ok(result);
    }
    [HttpGet("scene")]
    public async Task<IActionResult> GetScene(Guid gameId, Guid choiceId)
    {
        var result = await _gameService.GetScene(gameId ,choiceId);

        return Ok(result);
    }
}