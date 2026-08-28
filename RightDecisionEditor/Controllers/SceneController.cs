using Microsoft.AspNetCore.Mvc;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Services;

namespace RightDecisionEditor.Controllers;

[ApiController]
[Route("api/scene")]
public class SceneController(SceneService sceneService) : ControllerBase
{
    private readonly SceneService _sceneService = sceneService;

    [HttpPost("createScene")]
    public async Task<IActionResult> PostScene(SceneRequestDto sceneRequest)
    {
        var result = await _sceneService.PostScene(sceneRequest);

        return Ok(result);
    }
}