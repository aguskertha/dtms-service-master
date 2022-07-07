
namespace dtms_service_master.Models.Entities.Common
{
    public record BaseEntities
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public string UpdatedBy { get; set; } = string.Empty;

        public string DeletedBy { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public DateTimeOffset? CreateDate { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? UpdateDate { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? DeleteDate { get; set; } = DateTimeOffset.Now;
    }
    
}