namespace RightDecisionEditor.DTOs;

public class SceneRequestDto
{
    public Guid GameId { get; set; }
    public string? Title { get; set; }
    public required string Text { get; set; }
    public required bool FirstScene { get; set; }
}