using dtms_service_master.Repositories.Repo;

namespace dtms_service_master.Repositories
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IDummyRepository, DummyRepository>();
            services.AddSingleton<IVendorRepository, VendorRepository>();
            return services;
        }
    }
}
