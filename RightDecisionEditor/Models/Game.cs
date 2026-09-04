namespace RightDecisionEditor.Models;

public class Game(string title, string? description, bool isPublished)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public List<Scene> Scenes { get; set; } = [];
    public bool IsPublished { get; set; } = isPublished;
}