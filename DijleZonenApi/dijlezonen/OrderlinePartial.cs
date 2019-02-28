using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.dijlezonen
{
    public partial class Orderline
    {
        public Orderline()
        {
                
        }
        public Orderline(int orderId, int quantity, int productId)
        {
            this.OrderId = orderId;
            this.Quantity = quantity;
            this.ProductId = productId;
        }
    }
}
