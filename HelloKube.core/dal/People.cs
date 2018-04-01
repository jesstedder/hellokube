using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class People
    {
        public People()
        {
            BuyingGroups = new HashSet<BuyingGroups>();
            Cities = new HashSet<Cities>();
            Colors = new HashSet<Colors>();
            Countries = new HashSet<Countries>();
            CustomerCategories = new HashSet<CustomerCategories>();
            CustomerTransactions = new HashSet<CustomerTransactions>();
            CustomersAlternateContactPerson = new HashSet<Customers>();
            CustomersLastEditedByNavigation = new HashSet<Customers>();
            CustomersPrimaryContactPerson = new HashSet<Customers>();
            DeliveryMethods = new HashSet<DeliveryMethods>();
            InverseLastEditedByNavigation = new HashSet<People>();
            InvoiceLines = new HashSet<InvoiceLines>();
            InvoicesAccountsPerson = new HashSet<Invoices>();
            InvoicesContactPerson = new HashSet<Invoices>();
            InvoicesLastEditedByNavigation = new HashSet<Invoices>();
            InvoicesPackedByPerson = new HashSet<Invoices>();
            InvoicesSalespersonPerson = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
            OrdersContactPerson = new HashSet<Orders>();
            OrdersLastEditedByNavigation = new HashSet<Orders>();
            OrdersPickedByPerson = new HashSet<Orders>();
            OrdersSalespersonPerson = new HashSet<Orders>();
            PackageTypes = new HashSet<PackageTypes>();
            PaymentMethods = new HashSet<PaymentMethods>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            PurchaseOrdersContactPerson = new HashSet<PurchaseOrders>();
            PurchaseOrdersLastEditedByNavigation = new HashSet<PurchaseOrders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StateProvinces = new HashSet<StateProvinces>();
            StockGroups = new HashSet<StockGroups>();
            StockItemHoldings = new HashSet<StockItemHoldings>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            StockItems = new HashSet<StockItems>();
            SupplierCategories = new HashSet<SupplierCategories>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
            SuppliersAlternateContactPerson = new HashSet<Suppliers>();
            SuppliersLastEditedByNavigation = new HashSet<Suppliers>();
            SuppliersPrimaryContactPerson = new HashSet<Suppliers>();
            SystemParameters = new HashSet<SystemParameters>();
            TransactionTypes = new HashSet<TransactionTypes>();
        }

        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string SearchName { get; set; }
        public bool IsPermittedToLogon { get; set; }
        public string LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[] HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string UserPreferences { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<BuyingGroups> BuyingGroups { get; set; }
        public ICollection<Cities> Cities { get; set; }
        public ICollection<Colors> Colors { get; set; }
        public ICollection<Countries> Countries { get; set; }
        public ICollection<CustomerCategories> CustomerCategories { get; set; }
        public ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        public ICollection<Customers> CustomersAlternateContactPerson { get; set; }
        public ICollection<Customers> CustomersLastEditedByNavigation { get; set; }
        public ICollection<Customers> CustomersPrimaryContactPerson { get; set; }
        public ICollection<DeliveryMethods> DeliveryMethods { get; set; }
        public ICollection<People> InverseLastEditedByNavigation { get; set; }
        public ICollection<InvoiceLines> InvoiceLines { get; set; }
        public ICollection<Invoices> InvoicesAccountsPerson { get; set; }
        public ICollection<Invoices> InvoicesContactPerson { get; set; }
        public ICollection<Invoices> InvoicesLastEditedByNavigation { get; set; }
        public ICollection<Invoices> InvoicesPackedByPerson { get; set; }
        public ICollection<Invoices> InvoicesSalespersonPerson { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
        public ICollection<Orders> OrdersContactPerson { get; set; }
        public ICollection<Orders> OrdersLastEditedByNavigation { get; set; }
        public ICollection<Orders> OrdersPickedByPerson { get; set; }
        public ICollection<Orders> OrdersSalespersonPerson { get; set; }
        public ICollection<PackageTypes> PackageTypes { get; set; }
        public ICollection<PaymentMethods> PaymentMethods { get; set; }
        public ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrdersContactPerson { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrdersLastEditedByNavigation { get; set; }
        public ICollection<SpecialDeals> SpecialDeals { get; set; }
        public ICollection<StateProvinces> StateProvinces { get; set; }
        public ICollection<StockGroups> StockGroups { get; set; }
        public ICollection<StockItemHoldings> StockItemHoldings { get; set; }
        public ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        public ICollection<StockItems> StockItems { get; set; }
        public ICollection<SupplierCategories> SupplierCategories { get; set; }
        public ICollection<SupplierTransactions> SupplierTransactions { get; set; }
        public ICollection<Suppliers> SuppliersAlternateContactPerson { get; set; }
        public ICollection<Suppliers> SuppliersLastEditedByNavigation { get; set; }
        public ICollection<Suppliers> SuppliersPrimaryContactPerson { get; set; }
        public ICollection<SystemParameters> SystemParameters { get; set; }
        public ICollection<TransactionTypes> TransactionTypes { get; set; }
    }
}
