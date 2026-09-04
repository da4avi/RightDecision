using RightDecisionEditor.DTOs.Published;

namespace RightDecision.Contracts;

public class GamePublishedEvent(Guid gameId, string title, string? description, List<ScenePublishedDto> scenes)
{
    public Guid GameId { get; set; } = gameId;
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public List<ScenePublishedDto> Scenes { get; set; } = scenes;
}