using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class DeliveryMethods
    {
        public DeliveryMethods()
        {
            Customers = new HashSet<Customers>();
            Invoices = new HashSet<Invoices>();
            PurchaseOrders = new HashSet<PurchaseOrders>();
            Suppliers = new HashSet<Suppliers>();
        }

        public int DeliveryMethodId { get; set; }
        public string DeliveryMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<Customers> Customers { get; set; }
        public ICollection<Invoices> Invoices { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        public ICollection<Suppliers> Suppliers { get; set; }
    }
}
