using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface OrderDAO
    {
        Order Get(int id);
        Order GetByLocalId(string id);
        Order[] GetAll();
        //Order Create(
        //    string name,
        //    float price,
        //    string imageUrl,
        //    int inStock,
        //    int criticalStock);
        Order Create(Order order);
        Order Update(Order order);
        void Delete(int id);
        Order processOrder(Order order);

    }
}
