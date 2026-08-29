namespace RightDecisionEditor.DTOs;

public class ChoiceRequestDto
{
    public required Guid SceneId { get; set; }
    public required Guid NextSceneId { get; set; }
    public required string Text { get; set; }
}