using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface CustomerDAO
    {
        Customer Get(int id);
        Customer GetByUsername(string userName);
        Customer[] GetAll();
        Customer Create(string lastName, string firstName, string role, float? creditBalance, string userName, string HashedPass, string salt);
        Customer Update(Customer customer);
        void Delete(int id);
    }
}
