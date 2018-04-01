using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class StockItemStockGroups
    {
        public int StockItemStockGroupId { get; set; }
        public int StockItemId { get; set; }
        public int StockGroupId { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public People LastEditedByNavigation { get; set; }
        public StockGroups StockGroup { get; set; }
        public StockItems StockItem { get; set; }
    }
}
