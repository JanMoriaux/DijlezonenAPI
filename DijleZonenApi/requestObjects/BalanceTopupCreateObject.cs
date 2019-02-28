using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class BalanceTopupCreateObject
    {
        public float Amount { get; set; }
        public int CustomerId { get; set; }
        public int CashierId { get; set; }
        public DateTime Timestamp { get; set; }
        public string LocalId { get; set; }
        public Balancetopup toBalanceTopup()
        {
            Balancetopup bt = new Balancetopup();
            bt.CustomerId = this.CustomerId;
            bt.CashierId = this.CashierId;
            bt.Amount = this.Amount;
            bt.Timestamp = this.Timestamp;
            bt.LocalId = this.LocalId;

            return bt;
        }
    }

  
}
