using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;

namespace DijleZonenApi.DAL
{
    public class EventSubscriptionDAOEfImpl : EventSubscriptionDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;
        public EventSubscriptionDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Eventsubscription Create(Eventsubscription eventsubscription)
        {
            this.dbContext.Add(eventsubscription);
            this.dbContext.SaveChanges();
            return eventsubscription;
        }

        public void Delete(int eventId, int customerId)
        {
            Eventsubscription eventsubscription = this.Get(eventId, customerId);
            this.dbContext.Remove(eventsubscription);
            this.dbContext.SaveChanges();
        }

        public Eventsubscription Get(int eventId, int customerId)
        {
            var eventSubscription = dbContext.Eventsubscription.FirstOrDefault(t => t.EventId == eventId && t.CustomerId == customerId);
            return eventSubscription;
        }

        public Eventsubscription[] GetAll()
        {
            return dbContext.Eventsubscription.ToArray();
        }

        public Eventsubscription Update(Eventsubscription eventsubscription)
        {
            this.dbContext.Eventsubscription.Update(eventsubscription);
            this.dbContext.SaveChanges();
            return eventsubscription;
        }
    }
}
