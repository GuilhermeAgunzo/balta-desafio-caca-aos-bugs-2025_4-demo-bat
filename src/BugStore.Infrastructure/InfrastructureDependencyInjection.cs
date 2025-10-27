using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=app.db");
        });
    }
}