using Scrutor;

namespace TestWork5.Configurations;

public static class ValidatorDependenciesConfiguration
{
    public static IServiceCollection AddValidatorDependencies(this IServiceCollection services)
    {
        services.Scan(
            options =>
            {
                options.FromCallingAssembly()

                    .AddClasses(i => i.Where(c => c.Name.EndsWith("Validator")))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
            });

        return services;
    }
}