using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Product
    {
        public Product()
        {
            Orderline = new HashSet<Orderline>();
        }

        public int Id { get; set; }
        public int CriticalStock { get; set; }
        public string ImageUrl { get; set; }
        public int InStock { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public ICollection<Orderline> Orderline { get; set; }
    }
}
