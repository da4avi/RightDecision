namespace RightDecisionEditor.Models;

public class Scene(string? title, string text, List<Guid> choicesId)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string? Title { get; set; } = title;
    public string Text { get; set; } = text;
    public List<Guid> choicesId { get; set; } = choicesId;
}