using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class CustomerResponseObject
    {
        public CustomerResponseObject()
        {

        }

        public CustomerResponseObject(int id, string lastName, string firstName, string role, float? creditBalance, string userName)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Role = role;
            this.CreditBalance = creditBalance;
            this.UserName = userName;
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public float? CreditBalance { get; set; }
        public string UserName { get; set; }
    }
}
