using FluentValidation;

namespace Backend_Exam_Project.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppValidators(this IServiceCollection services)
    {
        // registers all IValidator<> implementations found in the entry assembly and referenced assemblies
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
            .ToArray();

        services.AddValidatorsFromAssemblies(assemblies);
        return services;
    }
}
