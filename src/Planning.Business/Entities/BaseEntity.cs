using Common.Extensions.Object;

namespace Planning.Business.Entities
{
    public abstract class BaseEntity
    {
        protected int? Id { get; }
        protected DateTime CreatedAt { get; }
        protected DateTime UpdatedAt { get; }
        public string User { get; set; }
        public BaseEntity()
        {
            CreatedAt =  DateTimeOffset.Now.TimeZone("Europe/Rome");
            UpdatedAt =  DateTimeOffset.Now.TimeZone("Europe/Rome");
            User = "SYSTEM";
        }
        public BaseEntity(int? id, string? user)
        {
            Id = id;
            User = String.IsNullOrEmpty(user) ? "SYSTEM" : user;
        }
        public BaseEntity(int? id, DateTime? createdAt, DateTime? updatedAt, string? user)
        {
            Id = id;
            CreatedAt = createdAt.HasValue ? createdAt.Value : DateTimeOffset.Now.TimeZone("Europe/Rome");
            UpdatedAt = updatedAt.HasValue ? updatedAt.Value : DateTimeOffset.Now.TimeZone("Europe/Rome");
            User = String.IsNullOrEmpty(user) ? "SYSTEM": user;
        }

        public DateTime GetCreatedAt()
        {
            return CreatedAt;
        }
        public DateTime GetUpdatedAt()
        {
            return UpdatedAt;
        }
    }
}
