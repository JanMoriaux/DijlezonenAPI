using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Production
    {
        public Production()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
