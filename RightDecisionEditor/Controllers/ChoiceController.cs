using Microsoft.AspNetCore.Mvc;
using RightDecisionEditor.DTOs;
using RightDecisionEditor.Services;

namespace RightDecisionEditor.Controllers;

[ApiController]
[Route("api/choice")]
public class ChoiceController(ChoiceService choiceService) : ControllerBase
{
    private readonly ChoiceService _choiceService = choiceService;

    [HttpPost("createChoice")]
    public async Task<IActionResult> PostChoice(ChoiceRequestDto choiceRequest)
    {
        var result = await _choiceService.PostChoice(choiceRequest);

        return Ok(result);
    }
}