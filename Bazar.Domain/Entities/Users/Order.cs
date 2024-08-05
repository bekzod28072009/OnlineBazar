using Bazar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Entities.Users
{
    public class Order : Auditable
    {
        public int Price { get; set; }

        public string Information { get; set; }

        public int Number { get; set; }

    }
}
