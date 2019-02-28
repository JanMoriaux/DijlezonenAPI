using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.DAL;
using DijleZonenApi.dijlezonen;
using DijleZonenApi.requestObjects;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using DijleZonenApi.utilities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DijleZonenApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDAO customerDAO;
        
        public CustomerController(CustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CustomerResponseObject> Get()
        {
            List<CustomerResponseObject> objects = new List<CustomerResponseObject>();
            return customerDAO.GetAll().Select(customer => 
                new CustomerResponseObject(customer.Id, customer.LastName, customer.FirstName, customer.Role, customer.CreditBalance, customer.UserName));
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public CustomerResponseObject Get(int id)
        {
            Customer customer = new Customer();
            customer = this.customerDAO.Get(id);
            return new CustomerResponseObject(customer.Id, customer.LastName, customer.FirstName, customer.Role, customer.CreditBalance, customer.UserName);
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CustomerResponseObject))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]CustomerCreateObject customerCreateObject)
        {
            if (customerCreateObject == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if username already exists
            if (this.customerDAO.GetByUsername(customerCreateObject.UserName) == null ) { 

            HashedPassword hpwd = PasswordUtility.encryptPassword(customerCreateObject.Password);

            Customer customer = this.customerDAO.Create(
                customerCreateObject.LastName,
                customerCreateObject.FirstName,
                customerCreateObject.Role,
                customerCreateObject.CreditBalance,
                customerCreateObject.UserName,
                hpwd.HashedPwd, hpwd.Salt);

                CustomerResponseObject responseObject = new CustomerResponseObject
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Role = customer.Role,
                    CreditBalance = customer.CreditBalance,
                    UserName = customer.UserName
                };

                return CreatedAtRoute("GetCustomer", new { id = customer.Id }, responseObject);
            } else
            {
                return BadRequest("The username is already in use");
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerUpdateObject customerUpdateObject)
        {
            if (customerUpdateObject == null || id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = this.customerDAO.Get(id);

            if (customer == null)
            {
                return BadRequest();
            }

            customer.LastName = customerUpdateObject.LastName;
            customer.FirstName = customerUpdateObject.FirstName;
            customer.UserName = customerUpdateObject.UserName;
            customer.Role = customerUpdateObject.Role;
            customer.CreditBalance = customerUpdateObject.CreditBalance;

            if (customerUpdateObject.Password != null)
            {
                HashedPassword hpwd = PasswordUtility.encryptPassword(customerUpdateObject.Password);
                customer.HashedPass = hpwd.HashedPwd;
                customer.Salt = hpwd.Salt;

            }

            this.customerDAO.Update(customer);

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customerDAO.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.FirstName = "";
            customer.LastName = "";
            customer.UserName = "";
            customer.HashedPass = "";
            customer.Salt = "";

            customerDAO.Update(customer);

            return new NoContentResult();
        }
    }
}
