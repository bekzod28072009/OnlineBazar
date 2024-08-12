using Bazar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Common
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public long? CreatedBy { get; set; }
        public ItemState State { get; set; } = ItemState.Created;
    }
}
