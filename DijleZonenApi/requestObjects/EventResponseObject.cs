using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class EventResponseObject
    {
        public EventResponseObject(int id, string name, DateTime fromDate, float subscriptionFee, DateTime toDate, string type)
        {
            Id = id;
            Name = name;
            FromDate = fromDate;
            SubscriptionFee = subscriptionFee;
            ToDate = toDate;
            Type = type;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public float SubscriptionFee { get; set; }
        public DateTime ToDate { get; set; }
        public string Type { get; set; }
    }
}
