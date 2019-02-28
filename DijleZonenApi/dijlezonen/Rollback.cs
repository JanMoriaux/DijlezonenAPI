using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Rollback
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int CashierId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? TopupId { get; set; }

        public Customer Cashier { get; set; }
        public Order Order { get; set; }
        public Balancetopup Topup { get; set; }
    }
}
