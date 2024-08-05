using Bazar.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Entities.Others
{
    public class Address : Auditable
    {
        public string Country { get; set; }

        public string Region { get; set; }

        public string District { get; set; }
        
        public string AddressLine { get; set; }
    }
}
