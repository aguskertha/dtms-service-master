using dtms_service_master.Models.Entities;
using dtms_service_master.Repositories.Repo;

namespace dtms_service_master.Services.API
{
    public class VendorService
    {
        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository){
            _vendorRepository = vendorRepository;
        }

        public async Task<bool> Create(Vendor vendor)
        {
            return await _vendorRepository.Create(vendor);
        }

        public async Task<List<Vendor>> GetAll()
        {
            var vendors = await _vendorRepository.GetAll();
            return vendors;
        }

        public async Task<Vendor> GetById(Guid uuid)
        {
            var vendor = await _vendorRepository.GetById(uuid);
            if(vendor == null){
                throw new Exception("Vendor not found!");
            }
            return vendor;
        }
        public async Task<Vendor> GetByCode(string code)
        {
            var vendor = await _vendorRepository.GetByCode(code);
            if (vendor == null){
                throw new Exception("Vendor not found!");
            }
            return vendor;
        }

        public async Task<bool> DeleteById(Guid uuid)
        {
            var vendor = await _vendorRepository.GetById(uuid);
            if(vendor == null){
                throw new Exception("Vendor not found!");
            }
            vendor.IsDeleted = true;
            return await _vendorRepository.Update(vendor);
            
        }

        public async Task<bool> IsValid(Guid uuid)
        {
            var updateVendor = await _vendorRepository.GetById(uuid);
            if(updateVendor == null){
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateById(Vendor vendor)
        {
            if(!await IsValid(vendor.Id)){
                throw new Exception ("Vendor not found!");
            }
            return await _vendorRepository.Update(vendor);
        }
        
    }
}