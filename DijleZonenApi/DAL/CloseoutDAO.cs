using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface CloseoutDAO
    {
        Closeout Get(int id);
        Closeout[] GetAll();
        Closeout Create(Closeout balancetopups);
        Closeout Update(Closeout balancetopups);
        void Delete(int id);
    }
}
