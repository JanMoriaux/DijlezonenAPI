using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Orderline
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
