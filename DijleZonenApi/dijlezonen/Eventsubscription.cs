using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Eventsubscription
    {
        public int CustomerId { get; set; }
        public float RemainingCredit { get; set; }
        public int EventId { get; set; }

        public Customer Customer { get; set; }
        public Event Event { get; set; }
    }
}
