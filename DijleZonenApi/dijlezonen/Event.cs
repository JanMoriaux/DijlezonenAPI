using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Event
    {
        public Event()
        {
            Balancetopup = new HashSet<Balancetopup>();
            Eventsubscription = new HashSet<Eventsubscription>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public float SubscriptionFee { get; set; }
        public DateTime ToDate { get; set; }
        public string Type { get; set; }

        public ICollection<Balancetopup> Balancetopup { get; set; }
        public ICollection<Eventsubscription> Eventsubscription { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
