using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;
using Microsoft.EntityFrameworkCore;

namespace DijleZonenApi.DAL
{
    public class CustomerDAOEfImpl : CustomerDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;

        public CustomerDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Customer Create(string lastName, string firstName, string role, float? creditBalance, string userName, string hashedPass, string salt)
        {
            Customer customer = new Customer
            {
                LastName = lastName,
                FirstName = firstName,
                Role = role,
                CreditBalance = creditBalance,
                UserName = userName,
                HashedPass = hashedPass,
                Salt = salt
            };
            this.dbContext.Add(customer);
            this.dbContext.SaveChanges();
            return customer;

        }

        public void Delete(int id)
        {
            Customer customer = Get(id);
            this.dbContext.Remove(customer);
            this.dbContext.SaveChanges();
        }

        public Customer Get(int id)
        {
                return dbContext.Customer.FirstOrDefault(t => t.Id == id);
        }

        public Customer[] GetAll()
        {
            return dbContext.Customer.Where(cust => cust.UserName != null && cust.UserName != "").ToArray();
        }

        public Customer GetByUsername(string userName)
        {
            return dbContext.Customer.FirstOrDefault(t => t.UserName == userName);
        }

        public Customer Update(Customer customer)
        {
            this.dbContext.Customer.Update(customer);
            this.dbContext.SaveChanges();
            return customer;
        }
    }
}
