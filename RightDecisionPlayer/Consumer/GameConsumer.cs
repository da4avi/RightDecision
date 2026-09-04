using MassTransit;
using RightDecision.Contracts;
using RightDecisionPlayer.Data;
using RightDecisionPlayer.Models;

namespace RightDecisionPlayer.Consumer;

public class GamePublishedConsumer(AppDbContext context) : IConsumer<GamePublishedEvent>
{
    private readonly AppDbContext _context = context;
    public async Task Consume(ConsumeContext<GamePublishedEvent> context)
    {
        GamePublishedEvent eventMessage = context.Message;

        List<Scene> scenes = [.. eventMessage.Scenes.Select(scene => new Scene(
            scene.Id,
            scene.Title,
            scene.Text,
            [.. scene.Choices.Select(choice => new Choice(
                choice.Id,
                choice.Text,
                choice.NextSceneId
            ))],
            scene.FirstScene
        ))];

        Game game = new(
            eventMessage.GameId,
            eventMessage.Title,
            eventMessage.Description,
            scenes
        );

        _context.Games.Add(game);

        await _context.SaveChangesAsync();
    }
}