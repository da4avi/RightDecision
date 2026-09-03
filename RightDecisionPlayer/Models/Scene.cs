namespace RightDecisionPlayer.Models;

public class Scene
{
    public Scene() {}

    public Scene(Guid id, string? title, string text, List<Choice> choices, bool firstScene)
    {
        Id = id;
        Title = title;
        Text = text;
        Choices = choices;
        FirstScene = firstScene;
    }

    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string Text { get; set; } = string.Empty;
    public List<Choice> Choices { get; set; } = [];
    public bool FirstScene { get; set; } = false;
}