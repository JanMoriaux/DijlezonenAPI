using DijleZonenApi.dijlezonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.requestObjects
{
    public class BalanceTopupResponseObject
    {
        public int Id { get; set; }
        public string LocalId { get; set; }
        public float Amount { get; set; }
        public int CustomerId { get; set; }
        public int CashierId { get; set; }
        public int? EventId { get; set; }

        public Balancetopup toBalanceTopup()
        {
            Balancetopup bt = new Balancetopup();
            bt.Id = this.Id;
            bt.CustomerId = this.CustomerId;
            bt.CashierId = this.CashierId;
            bt.EventId = this.EventId;
            bt.Amount = this.Amount;
            bt.LocalId = this.LocalId;

            return bt;
        }

        public BalanceTopupResponseObject toRequestObject(Balancetopup bt)
        {
            BalanceTopupResponseObject br = new BalanceTopupResponseObject();
            br.Id = bt.Id;
            br.Amount = bt.Amount;
            br.CustomerId = bt.CustomerId;
            br.CashierId = bt.CashierId;
            br.EventId = bt.EventId;
            br.LocalId = bt.LocalId;
            return br;
        }
    }
}
