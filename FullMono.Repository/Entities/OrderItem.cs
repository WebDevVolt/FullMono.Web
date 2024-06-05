using FullMono.Repository.Core;

namespace FullMono.Repository.Entities
{
    public class OrderItem : EntityBase
    {
        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
