using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs
{
    public class AddressDto
    {
        public string Country { get; set; }

        public string Region { get; set; }

        public string District { get; set; }

        public string AddressLine { get; set; }
    }
}
