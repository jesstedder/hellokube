using System;
using System.Collections.Generic;

namespace HelloKube.core.dal
{
    public partial class StockItemHoldings
    {
        public int StockItemId { get; set; }
        public int QuantityOnHand { get; set; }
        public string BinLocation { get; set; }
        public int LastStocktakeQuantity { get; set; }
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public People LastEditedByNavigation { get; set; }
        public StockItems StockItem { get; set; }
    }
}
