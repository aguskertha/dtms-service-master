
using dtms_service_master.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dtms_service_master.Repositories.Repo
{
    public class DummyRepository : IDummyRepository
    {
        // private readonly ServiceMasterContext _context;
        private readonly IDbContextFactory<ServiceMasterContext> _context;
        public DummyRepository(IDbContextFactory<ServiceMasterContext> context) {
            _context = context;
        }
    
        public async Task<bool> Create(Dummy dummy)
        {
            // await _context.Dummies.AddAsync(dummy);
            // await _context.SaveChangesAsync();
            using (var context = _context.CreateDbContext())
            {
                await context.Dummies.AddAsync(dummy);
                await context.SaveChangesAsync();   
            }
            return true;
        }
    }
}