using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface EventDAO
    {
        Event Get(int id);
        Event[] GetAll();
        Event Create(Event myEvent);
        Event Update(Event myEvent);
        void Delete(int id);
    }
}
