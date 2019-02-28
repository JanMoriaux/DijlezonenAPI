using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.DAL;
using DijleZonenApi.dijlezonen;
using DijleZonenApi.requestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DijleZonenApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/EventSubscription")]
    public class EventSubscriptionController : Controller
    {
        private readonly EventSubscriptionDAO eventSubscriptionDAO;
        private readonly CustomerDAO customerDAO;
        private readonly EventDAO eventDAO;

        public EventSubscriptionController(EventSubscriptionDAO eventSubscriptionDAO,CustomerDAO customerDAO,EventDAO eventDAO)
        {
            this.eventSubscriptionDAO = eventSubscriptionDAO;
            this.customerDAO = customerDAO;
            this.eventDAO = eventDAO;
        }
        // GET: api/EventSubscription
        [HttpGet]
        public IEnumerable<EventSubscriptionResponseObject> Get()
        {
            return eventSubscriptionDAO.GetAll().Select(e => new EventSubscriptionResponseObject(e.CustomerId, e.RemainingCredit, e.EventId));
        }

        // GET: api/EventSubscription/5
        [HttpGet("{customerId}/{eventID}", Name = "GetEventSubscription")]
        [ProducesResponseType(200, Type = typeof(EventSubscriptionResponseObject))]
        [ProducesResponseType(404)]
        public IActionResult Get(int customerId, int eventId)
        {
            Eventsubscription item = this.eventSubscriptionDAO.Get(eventId, customerId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(new EventSubscriptionResponseObject(item.CustomerId, item.RemainingCredit, item.EventId));
        }
        
        // POST: api/EventSubscription
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EventSubscriptionResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]EventSubscriptionCreateObject value)
        {
            Customer customer = this.customerDAO.Get(value.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            Event ev = this.eventDAO.Get(value.EventId);

            if (ev == null)
            {
                return NotFound();
            }

            Eventsubscription eventsubscription = new Eventsubscription
            {
                EventId = value.EventId,
                CustomerId = value.CustomerId,
                RemainingCredit = ev.SubscriptionFee
            };

            this.eventSubscriptionDAO.Create(eventsubscription);

            EventSubscriptionResponseObject ro = new EventSubscriptionResponseObject(eventsubscription.CustomerId, eventsubscription.RemainingCredit, eventsubscription.EventId);

            return CreatedAtRoute("GetEventSubscription", new { customerId = ro.CustomerId, eventId = ro.EventId }, ro);
        }
        
        // PUT: api/EventSubscription/5
        [HttpPut("{customerId}/{eventID}")]
        public IActionResult Put(int customerId, int eventId, [FromBody]EventSubscriptionCreateObject value)
        {
            if (value == null || customerId == 0 || eventId == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Eventsubscription eventSubscription = this.eventSubscriptionDAO.Get(eventId, customerId);

            if (eventSubscription == null)
            {
                return NotFound();
            }

            eventSubscription.CustomerId = customerId;
            eventSubscription.EventId = eventId;
            eventSubscription.RemainingCredit = value.RemainingCredit;

            this.eventSubscriptionDAO.Update(eventSubscription);

            return NoContent();


        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{customerId}/{eventID}")]
        public void Delete(int customerId, int eventId)
        {
            this.eventSubscriptionDAO.Delete(eventId, customerId);
        }
    }

    public class EventSubscriptionCreateObject
    {
        public int CustomerId { get; set; }
        public float RemainingCredit { get; set; }
        public int EventId { get; set; }
    }
}
