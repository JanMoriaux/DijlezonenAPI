using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Balancetopup
    {
        public Balancetopup()
        {
            Rollback = new HashSet<Rollback>();
        }

        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public int CustomerId { get; set; }
        public int CashierId { get; set; }
        public string LocalId { get; set; }
        public int? EventId { get; set; }

        public Customer Cashier { get; set; }
        public Customer Customer { get; set; }
        public Event Event { get; set; }
        public ICollection<Rollback> Rollback { get; set; }
    }
}
