
using dtms_service_master.Models.Entities;

namespace dtms_service_master.Repositories.Repo
{
    public interface IVendorRepository
    {
        public Task<bool> Create(Vendor vendor);
        public Task<List<Vendor>> GetAll();
        public Task<Vendor?> GetById(Guid uuid);
        public Task<Vendor?> GetByCode(string code);
        public Task<bool> Update(Vendor vendor);
    }
}
