using AutoMapper;
using dtms_service_master.Protos;
using dtms_service_master.Models.Entities;

namespace dtms_service_master.Models
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateRequest, Vendor>();
            CreateMap<VendorsResponse, List<Vendor>>();
            CreateMap<VendorResponse, Vendor>();
            CreateMap<UpdateRequest, Vendor>();
        }
    }
}