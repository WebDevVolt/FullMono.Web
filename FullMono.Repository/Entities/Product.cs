using FullMono.Repository.Core;

namespace FullMono.Repository.Entities
{
    public class Product : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
