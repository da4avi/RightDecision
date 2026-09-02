using Microsoft.AspNetCore.Mvc;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Services;

namespace RightDecisionEditor.Controllers;

[ApiController]
[Route("api/game")]
public class GameController(GameService gameService) : ControllerBase
{
    private readonly GameService _gameService = gameService;

    [HttpPost("createGame")]
    public async Task<IActionResult> PostGame(GameRequestDto gameRequest)
    {
        var result = await _gameService.PostGame(gameRequest);

        return Ok(result);
    }
    [HttpGet("firstScene")]
    public async Task<IActionResult> GetFirstScene(Guid gameId)
    {
        var result = await _gameService.GetFirstScene(gameId);

        return Ok(result);
    }
    [HttpGet("scene")]
    public async Task<IActionResult> GetScene(Guid choiceId)
    {
        var result = await _gameService.GetScene(choiceId);

        return Ok(result);
    }
}