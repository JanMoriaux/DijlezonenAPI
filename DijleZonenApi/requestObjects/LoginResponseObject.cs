using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class LoginResponseObject
    {
        public LoginResponseObject(string token, CustomerResponseObject customerResponseObject)
        {
            this.Token = token;
            this.Customer = customerResponseObject;
        }
        public string Token { get; set; }
        public CustomerResponseObject Customer { get; set; }
    }
}
