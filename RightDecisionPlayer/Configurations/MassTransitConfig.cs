using MassTransit;
using RightDecisionPlayer.Consumer;
namespace RightDecisionPlayer.Configurations;

public static class MassTransitConfig
{
    public static IServiceCollection AddMassTransitConfig(
        this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<GamePublishedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });  
            
        });

        return services;
    }
}