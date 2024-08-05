using Bazar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Domain.Entities.Taxi
{
    public class Orders : Auditable
    {
        public string NumberOfOrders { get; set; }

        public int CostOfDelivery { get; set; }

        public string Interval { get; set; }

        public string PercentOfProfit { get; set; }
    }
}
