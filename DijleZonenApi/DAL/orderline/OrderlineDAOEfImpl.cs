using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;

namespace DijleZonenApi.DAL.orderline
{
    public class OrderlineDAOEfImpl : OrderlineDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;

        public OrderlineDAOEfImpl ()
        {
            this.dbContext = new _1718_SPRINGDBContext();
        }

        public void AddRange(Orderline[] orderlines)
        {
            this.dbContext.AddRange(orderlines);
        }
    }
}
