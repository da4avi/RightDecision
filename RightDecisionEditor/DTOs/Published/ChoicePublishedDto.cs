namespace RightDecisionEditor.DTOs.Published;

public class ChoicePublishedDto(Guid id, string text, Guid nextSceneId)
{
    public Guid Id { get; set; } = id;
    public string Text { get; set; } = text;
    public Guid NextSceneId { get; set; } = nextSceneId;
}