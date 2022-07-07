

using dtms_service_master.Models.Entities;
using dtms_service_master.Services.API;
using Grpc.Core;

namespace dtms_service_master.Controllers
{
    public class DummyController : DummyProto.DummyProtoBase
    {
        private readonly DummyService _dummyService;

        public DummyController(DummyService dummyService)
        {
            _dummyService = dummyService;
        }

        public override async Task<DummyResponse> CreateDummy(DummyRequestCreate request, ServerCallContext context){
            var newDummy = new Dummy {
                Body = request.Body
            };
            bool valid = await _dummyService.Create(newDummy);
            return new DummyResponse{
                Message = DateTimeOffset.Now.ToString()
            };
        }

    }
}