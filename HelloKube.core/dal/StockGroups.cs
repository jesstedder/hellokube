using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class StockGroups
    {
        public StockGroups()
        {
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
        }

        public int StockGroupId { get; set; }
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<SpecialDeals> SpecialDeals { get; set; }
        public ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
    }
}
