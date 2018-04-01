using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class Invoices
    {
        public Invoices()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InvoiceLines = new HashSet<InvoiceLines>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int BillToCustomerId { get; set; }
        public int? OrderId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ContactPersonId { get; set; }
        public int AccountsPersonId { get; set; }
        public int SalespersonPersonId { get; set; }
        public int PackedByPersonId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsCreditNote { get; set; }
        public string CreditNoteReason { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public int TotalDryItems { get; set; }
        public int TotalChillerItems { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
        public string ReturnedDeliveryData { get; set; }
        public DateTime? ConfirmedDeliveryTime { get; set; }
        public string ConfirmedReceivedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public People AccountsPerson { get; set; }
        public Customers BillToCustomer { get; set; }
        public People ContactPerson { get; set; }
        public Customers Customer { get; set; }
        public DeliveryMethods DeliveryMethod { get; set; }
        public People LastEditedByNavigation { get; set; }
        public Orders Order { get; set; }
        public People PackedByPerson { get; set; }
        public People SalespersonPerson { get; set; }
        public ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        public ICollection<InvoiceLines> InvoiceLines { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
