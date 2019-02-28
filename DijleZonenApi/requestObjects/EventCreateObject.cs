using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class EventCreateObject
    {
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public float SubscriptionFee { get; set; }
        public DateTime ToDate { get; set; }
        public string Type { get; set; }
    }
}
