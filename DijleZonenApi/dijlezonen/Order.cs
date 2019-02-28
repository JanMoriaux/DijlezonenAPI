using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Order
    {
        public Order()
        {
            Orderline = new HashSet<Orderline>();
            Rollback = new HashSet<Rollback>();
        }

        public int Id { get; set; }
        public float AmtPayedFromCredit { get; set; }
        public float AmtPayedFromSubscriptionFee { get; set; }
        public int CashierId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LocalId { get; set; }
        public int EventId { get; set; }

        public Customer Cashier { get; set; }
        public Customer Customer { get; set; }
        public Event Event { get; set; }
        public ICollection<Orderline> Orderline { get; set; }
        public ICollection<Rollback> Rollback { get; set; }
    }
}
