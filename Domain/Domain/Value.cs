using System;
using System.Collections.Generic;

namespace Domain.Domain
{
    public class Value : Entity<long>
    {
        public Value()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<ValueWork> ValueWorks { get; set; }


    }
}
