using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace DI
{
    public static class NativeInjectorBootstrapper
    {
        public static ServiceProvider GetProvider(IServiceCollection services)
        {
            RegistrarServices(services);
            return services.BuildServiceProvider();
        }

        public static void RegistrarServices(IServiceCollection services)
        {
            services.AddSingleton<IDivisorService, DivisorService>();
        }
    }
}
