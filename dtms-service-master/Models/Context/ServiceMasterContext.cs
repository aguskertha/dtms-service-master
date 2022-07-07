using dtms_service_master.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dtms_service_master.Models.Context
{
    public class ServiceMasterContext : DbContext
    {

        public ServiceMasterContext(DbContextOptions<ServiceMasterContext> options) : base(options) 
        { 
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            
        }
         public DbSet<Dummy> Dummies => Set<Dummy>();
         public DbSet<Vendor> Vendors => Set<Vendor>();

    }
}