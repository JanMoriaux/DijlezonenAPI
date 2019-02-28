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
    [Route("api/BalanceTopup")]
    public class BalanceTopupController : Controller
    {
        private readonly BalanceTopupDAO balanceTopupDAO;
        private readonly CustomerDAO customerDAO;

        public BalanceTopupController(BalanceTopupDAO balanceTopupDAO,CustomerDAO customerDAO)
        {
            this.balanceTopupDAO = balanceTopupDAO;
            this.customerDAO = customerDAO;
        }

        // GET: api/BalanceTopup
        [HttpGet]
        public IEnumerable<BalanceTopupResponseObject> Get()
        {
            Balancetopup[] bts = this.balanceTopupDAO.GetAll();
            BalanceTopupResponseObject[] btrs = new BalanceTopupResponseObject[bts.Length];

            for (int i = 0; i < btrs.Length; i++)
            {
                btrs[i] = new BalanceTopupResponseObject();
                btrs[i] = btrs[i].toRequestObject(bts[i]);
            }

            return btrs;
        }

        // GET: api/BalanceTopup/5
        [HttpGet("{id}", Name = "GetBalanceTopup")]
        public BalanceTopupResponseObject Get(int id)
        {
            BalanceTopupResponseObject br = new BalanceTopupResponseObject();
            br = br.toRequestObject(this.balanceTopupDAO.Get(id));
            return br;
        }
        
        // POST: api/BalanceTopup
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Balancetopup))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]BalanceTopupCreateObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Balancetopup topup = value.toBalanceTopup();
            // get customer
            Customer customer = this.customerDAO.Get(value.CustomerId);

            if (customer == null)
            {
                return BadRequest();
            }

            // get Cashier

            Customer cashier = this.customerDAO.Get(value.CashierId);

            if (cashier == null)
            {
                return BadRequest();
            }

            topup.Timestamp = DateTime.Now;

            this.balanceTopupDAO.Create(topup);
           
            customer.CreditBalance += value.Amount;

            this.customerDAO.Update(customer);

            return CreatedAtRoute("GetBalanceTopup", new { id = topup.Id }, topup);
        }

        // POST: api/BalanceTopup
        [HttpPost("/api/BalanceTopup/CreateRange")]
        [ProducesResponseType(201, Type = typeof(Balancetopup))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]BalanceTopupCreateObject[] topups)
        {
            if (topups == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (BalanceTopupCreateObject value in topups) { 

                Balancetopup topup = value.toBalanceTopup();
                // get customer
                Customer customer = this.customerDAO.Get(value.CustomerId);

                if (customer == null)
                {
                    return BadRequest();
                }

                // get Cashier

                Customer cashier = this.customerDAO.Get(value.CashierId);

                if (cashier == null)
                {
                    return BadRequest();
                }

                topup.Timestamp = DateTime.Now;

                this.balanceTopupDAO.Create(topup);

                customer.CreditBalance += value.Amount;

                this.customerDAO.Update(customer);
            }

            return Ok();
        }

    }
}
