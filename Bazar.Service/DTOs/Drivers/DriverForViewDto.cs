using Bazar.Domain.Entities.Others;
using Bazar.Domain.Entities.Taxi;
using Bazar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs.Drivers
{
    public class DriverForViewDto
    {
        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public DriverStatus Status { get; set; }

        public Orders Order { get; set; }
    }
}
