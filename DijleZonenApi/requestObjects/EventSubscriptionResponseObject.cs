using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class EventSubscriptionResponseObject
    {
        public EventSubscriptionResponseObject(int customerId, float remainingCredit, int eventId)
        {
            CustomerId = customerId;
            RemainingCredit = remainingCredit;
            EventId = eventId;
        }

        public int CustomerId { get; set; }
        public float RemainingCredit { get; set; }
        public int EventId { get; set; }
    }
}
