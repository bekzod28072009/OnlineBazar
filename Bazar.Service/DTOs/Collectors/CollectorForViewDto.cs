using Bazar.Domain.Entities.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs.Collectors
{
    public class CollectorForViewDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string UserName { get; set; }

        public Address Address { get; set; }
    }
}
