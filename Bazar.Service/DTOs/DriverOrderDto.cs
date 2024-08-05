using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs
{
    public class DriverOrderDto
    {
        public string NumberOfOrders { get; set; }

        public int CostOfDelivery { get; set; }

        public string Interval { get; set; }

        public string PercentOfProfit { get; set; }
    }
}
