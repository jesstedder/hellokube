using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class CustomerTransactions
    {
        public int CustomerTransactionId { get; set; }
        public int CustomerId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PaymentMethodId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountExcludingTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal OutstandingBalance { get; set; }
        public DateTime? FinalizationDate { get; set; }
        public bool? IsFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public Customers Customer { get; set; }
        public Invoices Invoice { get; set; }
        public People LastEditedByNavigation { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public TransactionTypes TransactionType { get; set; }
    }
}
