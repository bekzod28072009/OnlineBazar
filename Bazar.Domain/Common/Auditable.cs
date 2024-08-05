using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Common
{
    public class Auditable
    {
        public int Id { get; set; }
        public DateTime IsCteated { get; set; }

        public DateTime? IsUpdated { get; set; }
    }
}
