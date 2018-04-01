using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class BuyingGroups
    {
        public BuyingGroups()
        {
            Customers = new HashSet<Customers>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        public int BuyingGroupId { get; set; }
        public string BuyingGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<Customers> Customers { get; set; }
        public ICollection<SpecialDeals> SpecialDeals { get; set; }
    }
}
