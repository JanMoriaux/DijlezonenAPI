using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DijleZonenApi.DAL;
using DijleZonenApi.dijlezonen;
using DijleZonenApi.requestObjects;
using DijleZonenApi.utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DijleZonenApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly CustomerDAO customerDAO;
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration,CustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
            this._configuration = configuration;
        }
        // GET: api/Login/5
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginResponseObject))]
        [ProducesResponseType(403)]
        public IActionResult Login([FromBody]LoginRequestObject loginRequestObject)
        {
            if (loginRequestObject == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = this.customerDAO.GetByUsername(loginRequestObject.UserName);

            if (customer == null) 
            {
                return BadRequest();
            } 

            bool correctPwd = PasswordUtility.isPasswordCorrect(loginRequestObject.Password, customer.HashedPass, customer.Salt);

            if (correctPwd)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, customer.UserName)
                };
                string myKey = _configuration["MySection:SecurityKey"];
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MySection:SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "dijlezonen.be",
                    audience: "dijlezonen.be",
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds);
                CustomerResponseObject customerResponseObject = new CustomerResponseObject(customer.Id, customer.LastName, customer.FirstName, customer.Role, customer.CreditBalance, customer.UserName);
                LoginResponseObject loginResponseObject = new LoginResponseObject(new JwtSecurityTokenHandler().WriteToken(token), customerResponseObject);
               
                return Ok(loginResponseObject);
            }
            else
            {
                return BadRequest(403);
            }


        }


    }
}
