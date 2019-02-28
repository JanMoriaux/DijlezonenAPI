using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;
using Microsoft.EntityFrameworkCore;

namespace DijleZonenApi.DAL
{
    public class OrderDAOEfImpl : OrderDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;

        public OrderDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Order Create(Order order)
        {
            this.dbContext.Order.Add(order);
            this.dbContext.SaveChanges();
            this.dbContext.SaveChanges();

            return order;
        }

        public void Delete(int id)
        {
            
                var order = dbContext.Order.FirstOrDefault(t => t.Id == id);
                dbContext.Remove(order);
                dbContext.SaveChanges();
        }

        public Order Get(int id)
        {
                var order = dbContext.Order
                    .Include(o => o.Customer)
                        .ThenInclude(c => c.Eventsubscription)
                    .Include(o => o.Cashier)
                    .Include(o => o.Event)
                    .Include(o => o.Orderline)
                        .ThenInclude(ol => ol.Product).FirstOrDefault(t => t.Id == id);
                return order;
        }

        public Order GetByLocalId(string id)
        {
            
                var order = dbContext.Order.FirstOrDefault(t => t.LocalId == id);
                return order;
        }

        public Order[] GetAll()
        {
            var orders = dbContext.Order
                   .Include(o => o.Customer)
                       .ThenInclude(c => c.Eventsubscription)
                   .Include(o => o.Cashier)
                   .Include(o => o.Event)
                   .Include(o => o.Orderline)
                       .ThenInclude(ol => ol.Product).ToArray();
            return orders;
        }

        public Order Update(Order order)
        {
                dbContext.Update(order);
                dbContext.SaveChanges();
                return order;
        }

        public Order processOrder(Order order)
        {
            // check if customer exists
            Customer customer = dbContext.Customer.FirstOrDefault(t => t.Id == order.CustomerId);

            if (customer == null)
            {
                return null;
            }

            // process amount paid from eventsub
            if (order.AmtPayedFromSubscriptionFee > 0)
            {
                Eventsubscription sub = dbContext.Eventsubscription.FirstOrDefault(p => p.CustomerId == order.CustomerId && p.EventId == order.EventId);

                if (sub == null)
                {
                    return null;
                }

                sub.RemainingCredit -= order.AmtPayedFromSubscriptionFee;
                dbContext.Update(sub);

            }

            // process amount paid from credit
            if (order.AmtPayedFromCredit > 0)
            {
                // deduct total from user credit
                customer.CreditBalance -= order.AmtPayedFromCredit;

                dbContext.Update(customer);
            }

            // update product quantities
            foreach (Orderline orderline in order.Orderline)
            {
                Product product = dbContext.Product.FirstOrDefault(p => p.Id == orderline.ProductId);
                product.InStock -= orderline.Quantity;
                dbContext.Update(product);
            }

            // insert order
            dbContext.Order.Add(order);

            dbContext.SaveChanges();

            return order;

           }
    }
}
