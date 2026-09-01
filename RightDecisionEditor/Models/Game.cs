namespace RightDecisionEditor.Models;

public class Game(string title, string? description,List<Guid> scenesId)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public List<Guid> ScenesId { get; set; } = scenesId;
}