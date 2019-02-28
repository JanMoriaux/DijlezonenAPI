using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DijleZonenApi.dijlezonen;
using DijleZonenApi.requestObjects;
using DijleZonenApi.DAL;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DijleZonenApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderDAO orderDAO;
        private readonly CustomerDAO customerDAO;
        private readonly ProductDAO productDAO;
        private readonly EventSubscriptionDAO eventSubscriptionDAO;
        public OrderController(OrderDAO orderDAO, CustomerDAO customerDAO, ProductDAO productDAO,EventSubscriptionDAO eventSubscriptionDAO)
        {
            this.orderDAO = orderDAO;
            this.customerDAO = customerDAO;
            this.productDAO = productDAO;
            this.eventSubscriptionDAO = eventSubscriptionDAO;
        }

        [HttpGet]
        public IEnumerable<OrderResponseObject> Get()
        {
            Order[] orders = orderDAO.GetAll();

            return orders.Select(order =>
                new OrderResponseObject(
                    order.Id,
                    order.LocalId,
                    order.EventId,
                    order.CustomerId,
                    new CustomerResponseObject(
                        order.Customer.Id,
                        order.Customer.LastName,
                        order.Customer.FirstName,
                        order.Customer.Role,
                        order.Customer.CreditBalance,
                        order.Customer.UserName),
                    new EventResponseObject(
                        order.Event.Id,
                        order.Event.Name,
                        order.Event.FromDate,
                        order.Event.SubscriptionFee,
                        order.Event.ToDate,
                        order.Event.Type),
                    order.CashierId,
                    new CustomerResponseObject(
                        order.Cashier.Id, 
                        order.Cashier.LastName, 
                        order.Cashier.FirstName, 
                        order.Cashier.Role, 
                        order.Cashier.CreditBalance, 
                        order.Cashier.UserName),
                    order.TimeStamp, 
                    order.AmtPayedFromCredit, 
                    order.AmtPayedFromSubscriptionFee, 
                    order.Orderline.Select(orderline => new OrderlineResponseObject(
                        orderline.OrderId, 
                        orderline.Quantity, 
                        orderline.ProductId, 
                        new ProductResponseObject(
                            orderline.Product.Id, 
                            orderline.Product.CriticalStock, 
                            orderline.Product.ImageUrl, 
                            orderline.Product.InStock, 
                            orderline.Product.Name, 
                            orderline.Product.Price)
                            )
                        )
                    )
                ).OrderByDescending(order => order.TimeStamp );
        }

        [HttpGet("{id}", Name = "GetOrder")]
        [ProducesResponseType(200, Type = typeof(OrderResponseObject))]
        [ProducesResponseType(404)]
        public IActionResult GetById(long id)
        {
            Order order = orderDAO.Get((int)id);

            if (order == null)
            {
                return NotFound();
            }

            OrderResponseObject orderResponseObject = new OrderResponseObject(
                    order.Id,
                    order.LocalId,
                    order.EventId,
                    order.CustomerId,
                    new CustomerResponseObject(
                        order.Customer.Id,
                        order.Customer.LastName,
                        order.Customer.FirstName,
                        order.Customer.Role,
                        order.Customer.CreditBalance,
                        order.Customer.UserName),
                    new EventResponseObject(
                        order.Event.Id,
                        order.Event.Name,
                        order.Event.FromDate,
                        order.Event.SubscriptionFee,
                        order.Event.ToDate,
                        order.Event.Type),
                    order.CashierId,
                    new CustomerResponseObject(
                        order.Cashier.Id,
                        order.Cashier.LastName,
                        order.Cashier.FirstName,
                        order.Cashier.Role,
                        order.Cashier.CreditBalance,
                        order.Cashier.UserName),
                    order.TimeStamp,
                    order.AmtPayedFromCredit,
                    order.AmtPayedFromSubscriptionFee,
                    order.Orderline.Select(orderline => new OrderlineResponseObject(
                        orderline.OrderId,
                        orderline.Quantity,
                        orderline.ProductId,
                        new ProductResponseObject(
                            orderline.Product.Id,
                            orderline.Product.CriticalStock,
                            orderline.Product.ImageUrl,
                            orderline.Product.InStock,
                            orderline.Product.Name,
                            orderline.Product.Price)
                            )
                        )
                    );

            return Ok(orderResponseObject);
        }

        // POST api/order
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Order))]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        public IActionResult Create([FromBody] OrderRequestObject order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order newOrder = order.toOrder();

            var result = this.orderDAO.processOrder(newOrder);

            if (result != null)
            {
                return BadRequest();
            }

            return Ok();

        }

        // POST api/order
        [HttpPost("/api/Order/CreateRange")]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        public IActionResult CreateRange([FromBody] OrderRequestObject[] orders)
        {
            if (orders == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (OrderRequestObject order in orders) {

                Order newOrder = order.toOrder();

                var result = this.orderDAO.processOrder(newOrder);

                if (result == null)
                {
                    return BadRequest();
                }

            }

            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = orderDAO.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            orderDAO.Delete(id);

            return new NoContentResult();
        }

    }
}
