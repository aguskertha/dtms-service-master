using dtms_service_master.Models.Entities.Common;

namespace dtms_service_master.Models.Entities
{
    public record Vendor : BaseEntities
    {
        public string Address {get; set;} = string.Empty; 
        public string Phone {get; set;} = string.Empty; 
        public string NPWP {get; set;} = string.Empty; 
        public DateTimeOffset ValidDate {get; set;} = DateTimeOffset.Now; 
        public DateTimeOffset ExpiredDate {get; set;} = DateTimeOffset.Now; 
    }
}