using Bazar.Domain.Entities.Others;
using Bazar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs
{
    public class CollectorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserRole UserRole { get; set; } = UserRole.Worker;

        public int PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public AddressDto Address { get; set; }
    }
}
