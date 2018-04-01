using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class TransactionTypes
    {
        public TransactionTypes()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        public ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
