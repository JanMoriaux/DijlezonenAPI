using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;

namespace DijleZonenApi.DAL
{
    public class EventDAOEfImpl : EventDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;

        public EventDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Event Create(Event myEvent)
        {
            this.dbContext.Add(myEvent);
            this.dbContext.SaveChanges();
            return myEvent;
        }

        public void Delete(int id)
        {
            Event myEvent = this.Get(id);
            this.dbContext.Remove(myEvent);
            this.dbContext.SaveChanges();
        }

        public Event Get(int id)
        {
            var myEvent = dbContext.Event.FirstOrDefault(t => t.Id == id);
            return myEvent;
        }

        public Event[] GetAll()
        {
            return dbContext.Event.ToArray();
        }

        public Event Update(Event myEvent)
        {
            this.dbContext.Event.Update(myEvent);
            this.dbContext.SaveChanges();
            return myEvent;
        }
    }
}
