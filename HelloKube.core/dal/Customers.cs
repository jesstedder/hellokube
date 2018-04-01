using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InverseBillToCustomer = new HashSet<Customers>();
            InvoicesBillToCustomer = new HashSet<Invoices>();
            InvoicesCustomer = new HashSet<Invoices>();
            Orders = new HashSet<Orders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int BillToCustomerId { get; set; }
        public int CustomerCategoryId { get; set; }
        public int? BuyingGroupId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int? AlternateContactPersonId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public decimal? CreditLimit { get; set; }
        public DateTime AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
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
        public Customers BillToCustomer { get; set; }
        public BuyingGroups BuyingGroup { get; set; }
        public CustomerCategories CustomerCategory { get; set; }
        public Cities DeliveryCity { get; set; }
        public DeliveryMethods DeliveryMethod { get; set; }
        public People LastEditedByNavigation { get; set; }
        public Cities PostalCity { get; set; }
        public People PrimaryContactPerson { get; set; }
        public ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        public ICollection<Customers> InverseBillToCustomer { get; set; }
        public ICollection<Invoices> InvoicesBillToCustomer { get; set; }
        public ICollection<Invoices> InvoicesCustomer { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<SpecialDeals> SpecialDeals { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
