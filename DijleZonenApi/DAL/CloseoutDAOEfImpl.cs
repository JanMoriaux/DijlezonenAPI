using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;

namespace DijleZonenApi.DAL
{
    public class CloseoutDAOEfImpl : CloseoutDAO
    {

        private _1718_SPRINGDBContext dbContext;

        public CloseoutDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Closeout Create(Closeout closeout)
        {
            dbContext.Add(closeout);
            dbContext.SaveChanges();

            return closeout;
        }

        public void Delete(int id)
        {
         
                var closeout = dbContext.Closeout.FirstOrDefault(t => t.Id == id);
                dbContext.Remove(closeout);
                dbContext.SaveChanges();
        }

        public Closeout Get(int id)
        {

            var closeout = dbContext.Closeout.FirstOrDefault(t => t.Id == id);
            return closeout;

        }

        public Closeout[] GetAll()
        {
            
                return dbContext.Closeout.ToArray();
        }

        public Closeout Update(Closeout closeout)
        {
            
                dbContext.Update(closeout);
                dbContext.SaveChanges();
                return closeout;
        }
    }
}
