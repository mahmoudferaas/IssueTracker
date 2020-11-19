using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Terkwaz.IssueTracker.Persistence.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}