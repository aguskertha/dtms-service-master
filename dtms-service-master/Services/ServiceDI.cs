using dtms_service_master.Services.API;

namespace dtms_service_master.Services
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<DummyService>();
            services.AddSingleton<VendorService>();
            
            return services;
        }
    }
}