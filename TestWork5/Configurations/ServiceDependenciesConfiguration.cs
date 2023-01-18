using Scrutor;
using TestWork5.Data.Validators.Common;

namespace TestWork5.Configurations;

public static class ServiceDependenciesConfiguration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddSingleton<Base64Validator>();
        services.Scan(
            options =>
            {
                options.FromCallingAssembly()

                    .AddClasses(i => i.Where(c => c.Name.EndsWith("Service")))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
            });

        return services;
    }
}