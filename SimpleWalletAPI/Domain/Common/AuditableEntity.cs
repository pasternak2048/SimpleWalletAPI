namespace Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedById { get; set; }
    }
}
