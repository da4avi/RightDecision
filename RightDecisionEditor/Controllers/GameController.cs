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
}