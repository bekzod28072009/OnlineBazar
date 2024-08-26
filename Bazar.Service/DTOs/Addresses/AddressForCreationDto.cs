using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs.Addresses
{
    public class AddressForCreationDto
    {
        public string Country { get; set; }

        public string Region { get; set; }
        [MaxLength(50)]
        public string District { get; set; }

        [MaxLength(100)]
        public string AddressLine { get; set; }
        public long UserId { get; set; }
    }
}
