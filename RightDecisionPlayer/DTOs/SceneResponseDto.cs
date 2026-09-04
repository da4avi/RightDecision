using RightDecisionPlayer.DTOs;

namespace RightDecisionPlayer.DTOs;

public class SceneResponseDto(string? title, string text, List<ChoiceResponseDto> choices)
{
    public string? Title { get; set; } = title;
    public string Text { get; set; } = text;
    public List<ChoiceResponseDto> Choices { get; set; } = choices;
}