using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.DAL
{
    public interface RollbackDAO
    {
        Rollback Get(int id);
        Rollback[] GetAll();
        Rollback Create(Rollback balancetopups);
        Rollback Update(Rollback balancetopups);
        void Delete(int id);
        Rollback processRollback(Rollback rollback, string orderLocalId, string topupLocalId);
    }
}
