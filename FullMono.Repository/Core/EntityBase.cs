namespace FullMono.Repository.Core
{
    public class EntityBase
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
