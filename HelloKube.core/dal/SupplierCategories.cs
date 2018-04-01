using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class SupplierCategories
    {
        public SupplierCategories()
        {
            Suppliers = new HashSet<Suppliers>();
        }

        public int SupplierCategoryId { get; set; }
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<Suppliers> Suppliers { get; set; }
    }
}
