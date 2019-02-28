using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class CustomerUpdateObject
    {
        public CustomerUpdateObject()
        {

        }

        public CustomerUpdateObject(string lastName, string firstName, string userName, string role, float creditBalance, string password)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.UserName = userName;
            this.Role = role;
            this.Password = password;
            this.CreditBalance = creditBalance;

        }
       
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public float? CreditBalance { get; set; }

    }
}
