using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 

namespace Backend.Shared;

public static class InsurerContextExtension
{

    /// <summary>
    /// Adds InsurerDbContext to the specfied
    /// IServiceCollection. Uses the SqLite database
    /// provider
    /// </summary>
    /// <param name="services"></param>
    /// <param name="relativePath"></param>
    /// <returns>An IServiceCollection that can be used to add more services</returns>
    public static IServiceCollection AddInsurerContext
        (this IServiceCollection services, string relativePath="..")
    {
        string databasePath = Path.Combine(relativePath, "Insurer.db");

        services.AddDbContext<InsurerDbContext>(options =>
        options.UseSqlite($"Data Source={databasePath}"));

        return services;
    }


    


}
