using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class OrderRequestObject
    {
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public int CashierId { get; set; }
        public DateTime TimeStamp { get; set; }
        public float AmtPayedFromCredit { get; set; }
        public float AmtPayedFromSubscriptionFee { get; set; }
        public string LocalId { get; set; }
        public ICollection<OrderlineRequestObject> Orderlines { get; set; }

        public float getOrderTotal()
        {
            float sum = 0;
            foreach (OrderlineRequestObject line in this.Orderlines)
            {
                sum += line.getTotal();
            }
            return sum;
        }

        public Order toOrder()
        {
            Order order = new Order();
            order.CustomerId = this.CustomerId;
            order.EventId = this.EventId;
            order.CashierId = this.CashierId;
            order.TimeStamp = this.TimeStamp;
            order.AmtPayedFromCredit = this.AmtPayedFromCredit;
            order.AmtPayedFromSubscriptionFee = this.AmtPayedFromSubscriptionFee;
            order.LocalId = this.LocalId;
            foreach (OrderlineRequestObject ol in this.Orderlines)
            {
                Orderline orderline = new Orderline(ol.OrderId, ol.Quantity, ol.ProductId);
                order.Orderline.Add(orderline);
            }
            return order;
        }

        public OrderRequestObject toRequestObject (Order order)
        {
            this.CustomerId = order.CustomerId;
            this.EventId = order.EventId;
            this.CashierId = order.CashierId;
            this.TimeStamp = order.TimeStamp;
            this.AmtPayedFromCredit = order.AmtPayedFromCredit;
            this.AmtPayedFromSubscriptionFee = order.AmtPayedFromSubscriptionFee;
            this.Orderlines = new List<OrderlineRequestObject>();
            this.LocalId = order.LocalId;
            foreach (Orderline ol in order.Orderline)
            {
                this.Orderlines.Add(new OrderlineRequestObject(ol.OrderId, ol.Quantity, ol.ProductId));
            }
            return this;
        }
    }

   
}
