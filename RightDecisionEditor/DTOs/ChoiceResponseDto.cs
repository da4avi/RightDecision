namespace RightDecisionEditor.DTOs;

public class ChoiceResponseDto(Guid id, string text)
{
    public Guid Id { get; set; } = id;
    public string Text { get; set; } = text;
}