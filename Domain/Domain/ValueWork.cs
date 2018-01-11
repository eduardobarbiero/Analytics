using System;

namespace Domain.Domain
{
    public class ValueWork : Entity<long>
    {
        public ValueWork()
        {
        }

        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public virtual Value Value { get; set; }
        public long ValueId { get; set; }


}
}
