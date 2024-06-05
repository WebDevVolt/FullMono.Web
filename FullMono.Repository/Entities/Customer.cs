using FullMono.Repository.Core;

namespace FullMono.Repository.Entities
{
    public class Customer : EntityBase
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }
    }
}
