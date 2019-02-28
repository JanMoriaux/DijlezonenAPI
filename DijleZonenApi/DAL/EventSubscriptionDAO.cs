using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface EventSubscriptionDAO
    {
        Eventsubscription Get(int eventId, int customerId);
        Eventsubscription[] GetAll();
        Eventsubscription Create(Eventsubscription myEvent);
        Eventsubscription Update(Eventsubscription myEvent);
        void Delete(int eventId, int customerId);
    }
}
