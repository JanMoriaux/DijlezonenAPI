using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly EventDAO eventDAO;

        public EventController(EventDAO eventDAO)
        {
            this.eventDAO = eventDAO;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<EventResponseObject> Get()
        {
            return eventDAO.GetAll().Select(e => new EventResponseObject(e.Id, e.Name, e.FromDate, e.SubscriptionFee, e.ToDate, e.Type ));
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "GetEvent")]
        [ProducesResponseType(200, Type = typeof(EventResponseObject))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            Event item = this.eventDAO.Get(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(new EventResponseObject(item.Id, item.Name, item.FromDate, item.SubscriptionFee, item.ToDate, item.Type));
        }
        
        // POST: api/Event
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EventResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]EventCreateObject item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventCreateObject, Event>();
            });
            var mapper = config.CreateMapper();

            Event ev = mapper.Map<EventCreateObject, Event>(item);
            
            this.eventDAO.Create(ev);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventCreateObject > ();
            });
            mapper = config.CreateMapper();

            EventResponseObject ro = mapper.Map<Event, EventResponseObject>(ev);

            return CreatedAtRoute("GetEvent", new { id = ev.Id }, ro);
        }
        
        // PUT: api/Event/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EventCreateObject eventCreateObject)
        {
            if (eventCreateObject == null || id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event ev = this.eventDAO.Get(id);

            if (ev == null)
            {
                return BadRequest();
            }

            ev.FromDate = eventCreateObject.FromDate;
            ev.ToDate = eventCreateObject.ToDate;
            ev.Name = eventCreateObject.Name;
            ev.SubscriptionFee = eventCreateObject.SubscriptionFee;

            this.eventDAO.Update(ev);

            return new NoContentResult();


        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ev = this.eventDAO.Get(id);

            if (ev == null)
            {
                return NotFound();
            }

            this.eventDAO.Delete(id);

            return new NoContentResult();
        }
    }
}
