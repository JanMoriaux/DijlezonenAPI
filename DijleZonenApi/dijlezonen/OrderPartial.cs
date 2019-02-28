using DijleZonenApi.requestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.dijlezonen
{
    public partial class Order
    {
        public Order(int id, float amtPayedFromCredit, float amtPayedFromSubscriptionFee, int cashierId, int customerId, DateTime timeStamp, string localId, int eventId)
        {
            Id = id;
            AmtPayedFromCredit = amtPayedFromCredit;
            AmtPayedFromSubscriptionFee = amtPayedFromSubscriptionFee;
            CashierId = cashierId;
            CustomerId = customerId;
            TimeStamp = timeStamp;
            LocalId = localId;
            EventId = eventId;
        }
    }
}
