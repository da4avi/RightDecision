namespace RightDecisionEditor.DTOs.Published;

public class ScenePublishedDto(Guid id ,string? title, string text, List<ChoicePublishedDto> choices, bool firstScene)
{
    public Guid Id { get; set; } = id;
    public string? Title { get; set; } = title;
    public string Text { get; set; } = text;
    public List<ChoicePublishedDto> Choices { get; set; } = choices;
    public bool FirstScene { get; set; } = firstScene;
}