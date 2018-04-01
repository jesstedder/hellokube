using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class PurchaseOrderLines
    {
        public int PurchaseOrderLineId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int StockItemId { get; set; }
        public int OrderedOuters { get; set; }
        public string Description { get; set; }
        public int ReceivedOuters { get; set; }
        public int PackageTypeId { get; set; }
        public decimal? ExpectedUnitPricePerOuter { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public People LastEditedByNavigation { get; set; }
        public PackageTypes PackageType { get; set; }
        public PurchaseOrders PurchaseOrder { get; set; }
        public StockItems StockItem { get; set; }
    }
}
