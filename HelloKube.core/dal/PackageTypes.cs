using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class PackageTypes
    {
        public PackageTypes()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            OrderLines = new HashSet<OrderLines>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            StockItemsOuterPackage = new HashSet<StockItems>();
            StockItemsUnitPackage = new HashSet<StockItems>();
        }

        public int PackageTypeId { get; set; }
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<InvoiceLines> InvoiceLines { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
        public ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        public ICollection<StockItems> StockItemsOuterPackage { get; set; }
        public ICollection<StockItems> StockItemsUnitPackage { get; set; }
    }
}
