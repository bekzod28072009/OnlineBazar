using Bazar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Entities.Commons
{
    public class Attachment : Auditable
    {
        public string Path { get; set; }
    }
}
