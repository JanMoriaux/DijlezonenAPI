using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.DAL;
using DijleZonenApi.dijlezonen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DijleZonenApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Rollback")]
    public class RollbackController : Controller
    {
        private readonly RollbackDAO rollbackDAO;
        private readonly OrderDAO orderDAO;
        private readonly EventSubscriptionDAO eventSubscriptionDAO;
        private readonly CustomerDAO customerDAO;
        private readonly BalanceTopupDAO balanceTopupDAO;

        public RollbackController(RollbackDAO rollbackDAO,OrderDAO orderDAO,EventSubscriptionDAO eventSubscriptionDAO,CustomerDAO customerDAO,BalanceTopupDAO balanceTopupDAO)
        {
            this.rollbackDAO = rollbackDAO;
            this.orderDAO = orderDAO;
            this.eventSubscriptionDAO = eventSubscriptionDAO;
            this.customerDAO = customerDAO;
            this.balanceTopupDAO = balanceTopupDAO;
            
        }

        // GET: api/Rollback
        [HttpGet]
        public IEnumerable<RollbackResponseObject> Get()
        {
            return rollbackDAO.GetAll().Select(rb => new RollbackResponseObject(rb.Id, rb.OrderId, rb.CashierId, rb.TimeStamp, rb.TopupId));
        }

        // GET: api/Rollback/5
        [HttpGet("{id}", Name = "GetRollback")]
        public RollbackResponseObject Get(int id)
        {
            Rollback closeout = rollbackDAO.Get(id);
            return new RollbackResponseObject(closeout.Id, closeout.OrderId, closeout.CashierId, new DateTime(), closeout.TopupId) ;
        }

        [HttpPost("/api/Rollback/CreateRange")]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        public IActionResult Post([FromBody]RollbackCreateObject[] rollbacks)
        {
            if (rollbacks == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (RollbackCreateObject rollback in rollbacks)
            {
                Rollback newRollback = new Rollback(null, rollback.CashierId, rollback.TimeStamp, null);
                newRollback = rollbackDAO.processRollback(newRollback, rollback.OrderId, rollback.TopupId);

                if (newRollback == null)
                {
                    return BadRequest();
                }
            }

            return Ok();
        }

        //// PUT: api/Rollback/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class RollbackCreateObject
    {
        public RollbackCreateObject(string orderId, int cashierId, string topupId, DateTime timeStamp)
        {
            OrderId = orderId;
            CashierId = cashierId;
            TopupId = topupId;
            TimeStamp = timeStamp;
        }

        public string OrderId { get; set; }
        public int CashierId { get; set; }
        public string TopupId { get; set; }
        public DateTime TimeStamp { get; set; }

    }

    public class RollbackResponseObject
    {
        public RollbackResponseObject(int id, int? orderId, int cashierId, DateTime timeStamp, int? balancetopupId)
        {
            Id = id;
            OrderId = orderId;
            CashierId = cashierId;
            TimeStamp = timeStamp;
            BalancetopupId = balancetopupId;
        }

        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int CashierId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? BalancetopupId { get; set; }
    }
}
