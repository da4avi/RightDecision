using Microsoft.AspNetCore.Mvc;

namespace RightDecisionEditor.Controllers;

[ApiController]
[Route("api/scene")]
public class SceneController : ControllerBase
{
    [HttpPost("createScene")]
    public  async Task<IActionResult> PostScene()
    {

        return Ok();
    }
}