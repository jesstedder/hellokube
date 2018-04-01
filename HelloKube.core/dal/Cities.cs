using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class Cities
    {
        public Cities()
        {
            CustomersDeliveryCity = new HashSet<Customers>();
            CustomersPostalCity = new HashSet<Customers>();
            SuppliersDeliveryCity = new HashSet<Suppliers>();
            SuppliersPostalCity = new HashSet<Suppliers>();
            SystemParametersDeliveryCity = new HashSet<SystemParameters>();
            SystemParametersPostalCity = new HashSet<SystemParameters>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateProvinceId { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public StateProvinces StateProvince { get; set; }
        public ICollection<Customers> CustomersDeliveryCity { get; set; }
        public ICollection<Customers> CustomersPostalCity { get; set; }
        public ICollection<Suppliers> SuppliersDeliveryCity { get; set; }
        public ICollection<Suppliers> SuppliersPostalCity { get; set; }
        public ICollection<SystemParameters> SystemParametersDeliveryCity { get; set; }
        public ICollection<SystemParameters> SystemParametersPostalCity { get; set; }
    }
}
