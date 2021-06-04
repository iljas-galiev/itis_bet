using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.EmailNotifications;
using Infrastructure.Notifications;
using Microsoft.AspNetCore.Builder;
using WebSocketManager;
using System;
using Chat;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services,
                    IConfiguration configuration)
        {
            services.AddSingleton<EmailSender>();
            services.AddSingleton<INotificator<bool>, EmailNotificator>();

            services.AddWebSocketManager();

            return services;
        }

        public static void ConfigureChat(this IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.MapWebSocketManager("/chat", new ChatHandler(new WebSocketConnectionManager()));
        }
    }
}
