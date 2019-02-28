using DijleZonenApi.DAL;
using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class OrderlineRequestObject
    {
        private readonly ProductDAO productDAO;
        public OrderlineRequestObject( int orderId, int quantity, int productId)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = quantity;
        }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public float getTotal()
        {
            Product apiProduct = productDAO.Get(this.ProductId);
            return this.Quantity * apiProduct.Price;
        }
    }
}
