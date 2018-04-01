using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            PurchaseOrders = new HashSet<PurchaseOrders>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            StockItems = new HashSet<StockItems>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierCategoryId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int AlternateContactPersonId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public string SupplierReference { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountBranch { get; set; }
        public string BankAccountCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string InternalComments { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People AlternateContactPerson { get; set; }
        public Cities DeliveryCity { get; set; }
        public DeliveryMethods DeliveryMethod { get; set; }
        public People LastEditedByNavigation { get; set; }
        public Cities PostalCity { get; set; }
        public People PrimaryContactPerson { get; set; }
        public SupplierCategories SupplierCategory { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        public ICollection<StockItems> StockItems { get; set; }
        public ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
