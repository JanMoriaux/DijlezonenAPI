using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;

namespace DijleZonenApi.DAL
{
    public class BalanceTopupDAOEfImpl : BalanceTopupDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;
        public BalanceTopupDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Balancetopup Create(Balancetopup balancetopups)
        {
            try {
                
                this.dbContext.Add(balancetopups);
                this.dbContext.SaveChanges();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error number: " + e.Number + " - " + e.Message);
            }
            return balancetopups;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Balancetopup Get(int id)
        {
            Balancetopup bt = dbContext.Balancetopup.FirstOrDefault(t => t.Id == id);
            return bt;
        }

        public Balancetopup GetByLocalId(string id)
        {
            Balancetopup bt = dbContext.Balancetopup.FirstOrDefault(t => t.LocalId == id);
            return bt;
        }

        public Balancetopup[] GetAll()
        {
            return dbContext.Balancetopup.ToArray();
        }

        public Product Update(Balancetopup balancetopups)
        {
            throw new NotImplementedException();
        }
    }
}
