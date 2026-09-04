namespace RightDecisionPlayer.Models;

public class Game
{
    public Game() {}

    public Game(Guid id, string title, string? description, List<Scene> scenes)
    {
        Id = id;
        Title = title;
        Description = description;
        Scenes = scenes;
    }

    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Scene> Scenes { get; set; } = [];
}