namespace RightDecisionEditor.Models;

public class Choice(string text, Guid sceneId, Guid nextSceneId)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SceneId { get; set; } = sceneId;
    public Guid NextSceneId { get; set; } = nextSceneId;
    public string Text { get; set; } = text;
}