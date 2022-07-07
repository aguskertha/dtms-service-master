using AutoMapper;
using dtms_service_master.Helpers;
using dtms_service_master.Models.Entities;
using dtms_service_master.Models.Validator;
using dtms_service_master.Protos;
using dtms_service_master.Services.API;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace dtms_service_master.Controllers
{
    public class VendorController : VendorProto.VendorProtoBase
    {
        private readonly VendorService _vendorService;
        private readonly IMapper _mapper;

        public VendorController(VendorService vendorService, IMapper mapper){
            _vendorService = vendorService;
            _mapper = mapper;
        }

        public override async Task<MutationResponse> Create(CreateRequest request, ServerCallContext context)
        {
            try
            {
                var validationResult = new CreateVendorValidator().Validate(request);
                if (!validationResult.IsValid)
                    return new MutationResponse
                    {
                        Success = false,
                        Errors = Utilities.GetValidationErrors(validationResult.Errors),
                        ErrorCode = 400
                    };
                var newVendor = new Vendor
                {
                    Name = request.Name,
                    Code = request.Code,
                    Address = request.Address,
                    Phone = request.Phone,
                    NPWP = request.NPWP,
                    ValidDate = request.ValidDate.ToDateTimeOffset(),
                    ExpiredDate = request.ExpiredDate.ToDateTimeOffset()
                };

                await _vendorService.Create(_mapper.Map<Vendor>(newVendor));

                return new MutationResponse
                {
                    Success = true,
                    Message = "Successfully create the Vendor"
                };
            }
            catch (System.Exception e)
            {
                return new MutationResponse
                {
                    Success = false,
                    Message = e.Message.ToString(),
                    ErrorCode = 500
                };
            }
            
        }

        public override async Task<MutationResponse> GetAll(Empty request, ServerCallContext context)
        {
            try
            { 
                var vendors = await _vendorService.GetAll();
                var vendorsResponse = new VendorsResponse(); 
                foreach (var vendor in vendors)
                {
                    vendorsResponse.Vendors.Add(
                        new VendorResponse{
                            Name = vendor.Name,
                            Code = vendor.Code,
                            Address = vendor.Address,
                            Phone = vendor.Phone,
                            NPWP = vendor.NPWP,
                            ValidDate = vendor.ValidDate.ToTimestamp(),
                            ExpiredDate = vendor.ExpiredDate.ToTimestamp()
                        }
                    );
                }
                
                return new MutationResponse
                {
                    Success = true,
                    Data = Any.Pack(_mapper.Map<VendorsResponse>(vendorsResponse)),
                    // Data = Any.Pack(_mapper.Map<VendorsResponse>(message)),
                    // Data = al,
                    Message = "Successfully get the Vendors"
                };
            }
            catch (System.Exception e)
            {
                return new MutationResponse
                {
                    Success = false,
                    Message = e.Message.ToString(),
                    ErrorCode = 500
                };
            }
        }
        
        public override async Task<MutationResponse> GetOne(OptionalParamRequest request, ServerCallContext context)
        {
            try
            {
                var validationResult = new OptionalParamValidator().Validate(request);
                if (!validationResult.IsValid)
                    return new MutationResponse
                    {
                        Success = false,
                        Errors = Utilities.GetValidationErrors(validationResult.Errors),
                        ErrorCode = 400
                    };
                var vendor = new Vendor();
                if(request.HasId){
                    try
                    {
                        vendor = await _vendorService.GetById(new Guid(request.Id));                    
                    }
                    catch (System.Exception e)
                    {
                         
                        return new MutationResponse
                        {
                            Success = false,
                            Message = e.Message.ToString(),
                            ErrorCode = 400
                        };
                    }
                }
                else if (request.HasCode){
                    try
                    {
                        vendor = await _vendorService.GetByCode(request.Code);                    
                    }
                    catch (System.Exception e)
                    {
                        
                        return new MutationResponse
                        {
                            Success = false,
                            Message = e.Message.ToString(),
                            ErrorCode = 400
                        };
                    }
                }
                else{
                    return new MutationResponse
                    {
                        Success = false,
                        Message = "Bad Request",
                        ErrorCode = 400
                    };
                }

                var vendorResponse = new VendorResponse {
                    Id = vendor.Id.ToString(),
                    Name = vendor.Name,
                    Code = vendor.Code,
                    Address = vendor.Address,
                    Phone = vendor.Phone,
                    NPWP = vendor.NPWP,
                    ValidDate = vendor.ValidDate.ToTimestamp(),
                    ExpiredDate = vendor.ExpiredDate.ToTimestamp()
                };
                
                return new MutationResponse
                {
                    Success = true,
                    Data = Any.Pack(vendorResponse),
                    Message = "Successfully get the Vendor"
                };
            }
            catch (System.Exception e)
            {
                return new MutationResponse
                {
                    Success = false,
                    Message = e.Message.ToString(),
                    ErrorCode = 500
                };
            }
        }

        public override async Task<MutationResponse> DeleteOne(OptionalParamRequest request, ServerCallContext context)
        {
            try
            {
                if(request.HasId){
                    try
                    {
                        var result = await _vendorService.DeleteById(new Guid(request.Id));     
                        return new MutationResponse
                        {
                            Success = true,
                            Message = "Successfully delete the Vendor"
                        };               
                    }
                    catch (System.Exception)
                    {
                        return new MutationResponse
                        {
                            Success = false,
                            Message = "Vendor not found!",
                            ErrorCode = 400
                        };
                    }
                }
                else{
                    return new MutationResponse
                    {
                        Success = false,
                        Message = "Bad Request",
                        ErrorCode = 400
                    };
                }
                
            }
            catch (System.Exception e)
            {
                return new MutationResponse
                {
                    Success = false,
                    Message = e.Message.ToString(),
                    ErrorCode = 500
                };
            }
        }

         public override async Task<MutationResponse> UpdateOne(UpdateRequest request, ServerCallContext context)
        {
            try
            {
                var validationResult = new UpdateVendorValidation().Validate(request);
                if (!validationResult.IsValid)
                    return new MutationResponse
                    {
                        Success = false,
                        Errors = Utilities.GetValidationErrors(validationResult.Errors),
                        ErrorCode = 400
                    };
                var updateVendor = new Vendor
                {
                    Id = new Guid(request.Id),
                    Name = request.Name,
                    Code = request.Code,
                    Address = request.Address,
                    Phone = request.Phone,
                    NPWP = request.NPWP,
                    ValidDate = request.ValidDate.ToDateTimeOffset(),
                    ExpiredDate = request.ExpiredDate.ToDateTimeOffset()
                };
                
                try
                {
                    await _vendorService.UpdateById(updateVendor);    
                    return new MutationResponse
                    {
                        Success = true,
                        Message = "Successfully update the Vendor"
                    };             
                }
                catch (System.Exception e)
                {
                    return new MutationResponse
                    {
                        Success = false,
                        Message = e.Message.ToString(),
                        ErrorCode = 400
                    };
                }
                
            }
            catch (System.Exception e){
                return new MutationResponse
                {
                    Success = false,
                    Message = e.Message.ToString(),
                    ErrorCode = 500
                };
            }
        }
    }
    
}