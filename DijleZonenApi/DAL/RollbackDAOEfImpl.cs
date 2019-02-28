using DijleZonenApi.dijlezonen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public class RollbackDAOEfImpl : RollbackDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;

        public RollbackDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Rollback Create(Rollback rollback)
        {
            try
            {
                dbContext.Add(rollback);
                dbContext.SaveChanges();
                return rollback;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {   
                var rollback = dbContext.Rollback.FirstOrDefault(t => t.Id == id);
                dbContext.Remove(rollback);
                dbContext.SaveChanges();
        }

        public Rollback Get(int id)
        {
                var rollback = dbContext.Rollback.FirstOrDefault(t => t.Id == id);
                return rollback;
        }

        public Rollback[] GetAll()
        {
                return dbContext.Rollback.ToArray();
        }

        public Rollback Update(Rollback rollback)
        {
                dbContext.Update(rollback);
                dbContext.SaveChanges();
                return rollback;
        }

        public Rollback processRollback(Rollback rollback, string orderLocalId, string topupLocalId)
        {
            //proces order rollback
            if (orderLocalId != null)
            {
                // get order by local id
                Order order = dbContext.Order.Include(o => o.Orderline).FirstOrDefault(t => t.LocalId == orderLocalId);

                if (order == null)
                {
                    return null;
                }

                // rollback amount paid from subscription fee
                if (order.AmtPayedFromSubscriptionFee > 0)
                {
                    Eventsubscription eventsubscription = dbContext.Eventsubscription.FirstOrDefault(t => t.EventId == order.EventId && t.CustomerId == order.CustomerId);
                    eventsubscription.RemainingCredit += order.AmtPayedFromSubscriptionFee;
                    dbContext.Update(eventsubscription);
                }

                // rollback amount paid from credit
                if (order.AmtPayedFromCredit > 0)
                {
                    Customer customer = dbContext.Customer.FirstOrDefault(c => c.Id == order.CustomerId);
                    customer.CreditBalance += order.AmtPayedFromCredit;
                    dbContext.Update(customer);
                }

                // rollback product quantities
                foreach (Orderline orderline in order.Orderline)
                {
                    Product product = dbContext.Product.FirstOrDefault(p => p.Id == orderline.ProductId);
                    product.InStock += orderline.Quantity;
                    dbContext.Update(product);
                }

                rollback.OrderId = order.Id;

            }

            // process topup rollback
            if (topupLocalId != null)
            {
                Balancetopup topup = dbContext.Balancetopup.FirstOrDefault(t => t.LocalId == topupLocalId);
                Customer customer = dbContext.Customer.FirstOrDefault(c => c.Id == topup.CustomerId);
                customer.CreditBalance -= topup.Amount;
                dbContext.Update(customer);
                rollback.TopupId = topup.Id;
            }

            dbContext.Rollback.Add(rollback);
            dbContext.SaveChanges();
            return rollback;
        }

    }
}
