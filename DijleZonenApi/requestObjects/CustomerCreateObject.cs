using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class CustomerCreateObject
    {
        public CustomerCreateObject()
        {

        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public float? CreditBalance { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

       
    }
}
