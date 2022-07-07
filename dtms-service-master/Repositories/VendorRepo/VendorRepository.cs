
using dtms_service_master.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dtms_service_master.Repositories.Repo
{
    public class VendorRepository : IVendorRepository
    {
        private readonly IDbContextFactory<ServiceMasterContext> _context;
        public VendorRepository(IDbContextFactory<ServiceMasterContext> context) {
            _context = context;
        }
    
        public async Task<bool> Create(Vendor vendor)
        {
            using (var context = _context.CreateDbContext())
            {
                await context.Vendors.AddAsync(vendor);
                await context.SaveChangesAsync();   
            }
            return true;
        }

        public async Task<List<Vendor>> GetAll()
        {
            using (var context = _context.CreateDbContext())
            {
                var vendors = from v in context.Vendors
                            where v.IsDeleted.Equals(false)
                            select v;

                return await vendors.ToListAsync();
            }
        }

        public async Task<Vendor?> GetByCode(string code)
        {
            using (var context = _context.CreateDbContext())
            {
                var vendor = await context.Vendors.FirstOrDefaultAsync(vendor => vendor.Code == code);
                return vendor;
            }
        }

        public async Task<Vendor?> GetById(Guid uuid)
        {
            using (var context = _context.CreateDbContext())
            {
                var vendor = await context.Vendors.FirstOrDefaultAsync(vendor => vendor.Id == uuid);
                return vendor;
            }
        }

        public async Task<bool> Update(Vendor vendor)
        {
            using (var context = _context.CreateDbContext())
            {
                context.Vendors.Update(vendor);
                await context.SaveChangesAsync();   
                return true;
            }
        }

    }
}