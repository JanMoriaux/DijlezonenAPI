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
    [Route("api/Closeout")]
    public class CloseoutController : Controller
    {
        private readonly CloseoutDAO closeoutDAO;
        private readonly CustomerDAO customerDAO;

        public CloseoutController(CloseoutDAO closeoutDAO,CustomerDAO customerDAO)
        {
            this.closeoutDAO = closeoutDAO;
            this.customerDAO = customerDAO;
        }

        // GET: api/Closeout
        [HttpGet]
        public IEnumerable<CloseoutResponseObject> Get()
        {
            return closeoutDAO.GetAll().Select(e => new CloseoutResponseObject(e.Id, e.ExpectedCash, e.CountedCash, e.CashierId, e.Timestamp));
        }

        // GET: api/Closeout/5
        [HttpGet("{id}", Name = "GetCloseout")]
        public CloseoutResponseObject Get(int id)
        {
            Closeout closeout = closeoutDAO.Get(id);
            return new CloseoutResponseObject(closeout.Id, closeout.ExpectedCash, closeout.CountedCash, closeout.CashierId, closeout.Timestamp);
        }

        // POST: api/Closeout
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Closeout))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]CloseoutCreateObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            // get cashier
            Customer customer = this.customerDAO.Get(value.CashierId);

            if (customer == null)
            {
                return BadRequest();
            }

            Closeout newCloseOut =  this.closeoutDAO.Create(new Closeout() { CashierId = value.CashierId, CountedCash = value.CountedCash, ExpectedCash = value.ExpectedCash });

            return CreatedAtRoute("GetCloseout", new { id = newCloseOut.Id }, new CloseoutResponseObject(newCloseOut.Id, newCloseOut.ExpectedCash, newCloseOut.CountedCash, newCloseOut.CashierId, newCloseOut.Timestamp));
        }

        // POST api/order
        [HttpPost("/api/Closeout/CreateRange")]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        public IActionResult CreateRange([FromBody] CloseoutCreateObject[] closeouts)
        {
            if (closeouts == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach(CloseoutCreateObject value in closeouts) { 

                // get cashier
                Customer customer = this.customerDAO.Get(value.CashierId);

                if (customer == null)
                {
                    return BadRequest();
                }

                Closeout newCloseOut = this.closeoutDAO.Create(new Closeout() { CashierId = value.CashierId, CountedCash = value.CountedCash, ExpectedCash = value.ExpectedCash });
            }

            return Ok();
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CloseoutCreateObject closeoutCreateObject)
        {
            if (closeoutCreateObject == null || id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Closeout closeout = this.closeoutDAO.Get(id);

            if (closeout == null)
            {
                return BadRequest();
            }

            closeout.CashierId = closeoutCreateObject.CashierId;
            closeout.CountedCash = closeoutCreateObject.CountedCash;
            closeout.ExpectedCash = closeoutCreateObject.ExpectedCash;

            this.closeoutDAO.Update(closeout);

            return new NoContentResult();


        }

        // DELETE: api/Closeout/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var closeout = this.closeoutDAO.Get(id);

            if (closeout == null)
            {
                return NotFound();
            }

            this.closeoutDAO.Delete(id);

            return new NoContentResult();
        }


    }

    public class CloseoutResponseObject
    {
        public CloseoutResponseObject(int id, float expectedCash, float countedCash, int cashierId, DateTime timestamp)
        {
            Id = id;
            ExpectedCash = expectedCash;
            CountedCash = countedCash;
            CashierId = cashierId;
            Timestamp = timestamp;
        }

        public int Id { get; set; }
        public float ExpectedCash { get; set; }
        public float CountedCash { get; set; }
        public int CashierId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class CloseoutCreateObject
    {
        public CloseoutCreateObject(float expectedCash, float countedCash, int cashierId, DateTime timestamp)
        {
            ExpectedCash = expectedCash;
            CountedCash = countedCash;
            CashierId = cashierId;
            Timestamp = timestamp;
        }

        public float ExpectedCash { get; set; }
        public float CountedCash { get; set; }
        public int CashierId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}