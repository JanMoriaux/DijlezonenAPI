using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class OrderlineResponseObject
    {
        public OrderlineResponseObject(int orderId, int quantity, int productId, ProductResponseObject product)
        {
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
            this.product = product;
        }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductResponseObject product { get; set; }
    }
}
