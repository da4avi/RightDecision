namespace RightDecisionEditor.Models;

public class Scene(Guid gameId, string? title, string text, bool firstScene)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid GameId { get; set; } = gameId;
    public string? Title { get; set; } = title;
    public string Text { get; set; } = text;
    public List<Choice> Choices { get; set; } = [];
    public bool FirstScene { get; set; } = firstScene;
}