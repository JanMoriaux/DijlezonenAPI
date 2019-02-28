using System;
using System.Collections.Generic;

namespace DijleZonenApi.dijlezonen
{
    public partial class Customer
    {
        public Customer()
        {
            BalancetopupCashier = new HashSet<Balancetopup>();
            BalancetopupCustomer = new HashSet<Balancetopup>();
            Closeout = new HashSet<Closeout>();
            Eventsubscription = new HashSet<Eventsubscription>();
            OrderCashier = new HashSet<Order>();
            OrderCustomer = new HashSet<Order>();
            Rollback = new HashSet<Rollback>();
        }

        public int Id { get; set; }
        public float? CreditBalance { get; set; }
        public string FirstName { get; set; }
        public string HashedPass { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }
        public string UserName { get; set; }

        public ICollection<Balancetopup> BalancetopupCashier { get; set; }
        public ICollection<Balancetopup> BalancetopupCustomer { get; set; }
        public ICollection<Closeout> Closeout { get; set; }
        public ICollection<Eventsubscription> Eventsubscription { get; set; }
        public ICollection<Order> OrderCashier { get; set; }
        public ICollection<Order> OrderCustomer { get; set; }
        public ICollection<Rollback> Rollback { get; set; }
    }
}
