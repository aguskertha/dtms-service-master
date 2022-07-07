using dtms_service_master.Models.Entities;
using dtms_service_master.Repositories.Repo;

namespace dtms_service_master.Services.API
{
    public class DummyService
    {
        private readonly IDummyRepository _dummyRepository;

        public DummyService(IDummyRepository dummyRepository)
        {
            _dummyRepository = dummyRepository;
        }

        public async Task<bool> Create(Dummy dummy)
        {
            await _dummyRepository.Create(dummy);
            return true;
        }

    }
}