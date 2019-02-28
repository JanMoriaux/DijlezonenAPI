using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class ProductResponseObject
    {
        public ProductResponseObject(int id, int criticalStock, string imageUrl, int inStock, string name, float price)
        {
            Id = id;
            CriticalStock = criticalStock;
            ImageUrl = imageUrl;
            InStock = inStock;
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public int CriticalStock { get; set; }
        public string ImageUrl { get; set; }
        public int InStock { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
