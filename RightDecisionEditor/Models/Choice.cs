namespace RightDecisionEditor.Models;

public class Choice(string text, Guid sceneId)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SceneId { get; set; } = sceneId;
    public string Text { get; set; } = text;
}