using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Extenstion
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<Database>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ITISBet")));
        
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<Database>();

            return services;
        }
    }
}