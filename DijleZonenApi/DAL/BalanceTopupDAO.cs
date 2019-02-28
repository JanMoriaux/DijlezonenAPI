using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface BalanceTopupDAO
    {
        Balancetopup Get(int id);
        Balancetopup GetByLocalId(string id);
        Balancetopup[] GetAll();
        Balancetopup Create(Balancetopup balancetopups);
        Product Update(Balancetopup balancetopups);
        void Delete(int id);
    }
}
