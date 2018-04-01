using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class StockItemTransactions
    {
        public int StockItemTransactionId { get; set; }
        public int StockItemId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? InvoiceId { get; set; }
        public int? SupplierId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public Customers Customer { get; set; }
        public Invoices Invoice { get; set; }
        public People LastEditedByNavigation { get; set; }
        public PurchaseOrders PurchaseOrder { get; set; }
        public StockItems StockItem { get; set; }
        public Suppliers Supplier { get; set; }
        public TransactionTypes TransactionType { get; set; }
    }
}
