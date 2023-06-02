using FileService.Application.Owner;
using FileService.Domain.Owner;
using Microsoft.Extensions.DependencyInjection;

namespace FileService.Infrastructure.IoC;

public static class ServicesInjectionExtension
{
    public static void AddRegisterServices(this IServiceCollection services)
    {
        //Domain service
        services.AddScoped<IOwnerUniquenessChacker, OwnerUniquenessChacker>();
    }
}
