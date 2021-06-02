using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.EmailNotifications;
using Infrastructure.Notifications;

namespace Infrastructure
{
    public static class Extentions
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection services,
                    IConfiguration configuration)
        {
            services.AddSingleton<EmailSender>();
            services.AddSingleton<INotificator<bool>, EmailNotificator>();

            return services;
        }
    }
}
