using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Persistence.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IssueTrackerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            services.AddScoped<IIssueTrackerDbContext>(provider => provider.GetService<IssueTrackerDbContext>());

            return services;
        }
    }
}