using Bazar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Entities.Taxi
{
    public class Car : Auditable
    {
        public string Name { get; set; }

        public int NumberOfCar { get; set; }

        public string Design { get; set; }
    }
}
