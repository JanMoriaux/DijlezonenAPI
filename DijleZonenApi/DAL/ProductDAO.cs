using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface ProductDAO
    {
        Product Get(int id);
        Product[] GetAll();
        Product Create(
            string name,
            float price,
            string imageUrl,
            int inStock,
            int criticalStock);
        Product Update(
           Product product);
        void Delete(int id);

    }
}
