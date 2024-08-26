using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs.Cars
{
    public class CarForUpdateDto
    {
        public string Name { get; set; }

        public int NumberOfCar { get; set; }

        public string Design { get; set; }

        public int Year { get; set; }

        public string Owner { get; set; }

        public string PhotoDescription { get; set; }
    }
}
