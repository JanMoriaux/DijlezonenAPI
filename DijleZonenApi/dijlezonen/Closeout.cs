using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Closeout
    {
        public int Id { get; set; }
        public float ExpectedCash { get; set; }
        public float CountedCash { get; set; }
        public int CashierId { get; set; }
        public DateTime Timestamp { get; set; }

        public Customer Cashier { get; set; }
    }
}
