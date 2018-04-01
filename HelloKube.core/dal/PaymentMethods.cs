using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class PaymentMethods
    {
        public PaymentMethods()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        public ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
