using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.dijlezonen
{
    public partial class Rollback
    {
        public Rollback(int id, int? orderId, int cashierId, DateTime timeStamp, int? balancetopupId)
        {
            Id = id;
            OrderId = orderId;
            CashierId = cashierId;
            TimeStamp = timeStamp;
            TopupId = balancetopupId;
        }

        public Rollback(int? orderId, int cashierId, DateTime timeStamp, int? balancetopupId)
        {
            OrderId = orderId;
            CashierId = cashierId;
            TimeStamp = timeStamp;
            TopupId = balancetopupId;
        }
    }
}
