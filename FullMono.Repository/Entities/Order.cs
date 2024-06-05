using FullMono.Repository.Core;

namespace FullMono.Repository.Entities
{
    public class Order : EntityBase
    {
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public required ICollection<OrderItem> OrderItems { get; set; }
    }
}
