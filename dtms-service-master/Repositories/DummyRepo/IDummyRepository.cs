
using dtms_service_master.Models.Entities;

namespace dtms_service_master.Repositories.Repo
{
    public interface IDummyRepository
    {
        public Task<bool> Create(Dummy dummy);
    }
}
