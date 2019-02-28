using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.dijlezonen
{
    public partial class Product
    {
        public Product(string name, float price, string imageUrl, int inStock, int criticalStock)
        {
            this.Name = name;
            this.Price = price;
            this.ImageUrl = imageUrl;
            this.InStock = inStock;
            this.CriticalStock = criticalStock;
        }
    }
}
