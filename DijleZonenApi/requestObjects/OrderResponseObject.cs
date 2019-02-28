using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class OrderResponseObject
    {
        public OrderResponseObject(int id, string LocalId, int eventId, int customerId, CustomerResponseObject customer, EventResponseObject @event, int cashierId, CustomerResponseObject cashier, DateTime timeStamp, float amtPayedFromCredit, float amtPayedFromSubscriptionFee, IEnumerable<OrderlineResponseObject> orderlines)
        {
            Id = id;
            EventId = eventId;
            CustomerId = customerId;
            Customer = customer;
            Event = @event;
            CashierId = cashierId;
            TimeStamp = timeStamp;
            AmtPayedFromCredit = amtPayedFromCredit;
            AmtPayedFromSubscriptionFee = amtPayedFromSubscriptionFee;
            Orderlines = orderlines;
            this.LocalId = LocalId;
        }
        public string LocalId { get; set; }
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public CustomerResponseObject Customer { get; set; }
        public EventResponseObject Event { get; set; }
        public int CashierId { get; set; }
        public CustomerResponseObject Cashier { get; set; }
        public DateTime TimeStamp { get; set; }
        public float AmtPayedFromCredit { get; set; }
        public float AmtPayedFromSubscriptionFee { get; set; }
        public IEnumerable<OrderlineResponseObject> Orderlines { get; set; }
    }
}
