namespace RightDecisionPlayer.Models;

public class Choice
{
    public Choice() { }

    public Choice(Guid id, string text, Guid nextSceneId)
    {
        Id = id;
        Text = text;
        NextSceneId = nextSceneId;
    }

    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public Guid NextSceneId { get; set; }
}