using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface OrderlineDAO
    {
        void AddRange(Orderline[] orderLines);
    }
}
