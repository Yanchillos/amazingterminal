using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows
{
    public class CustomWithPointRow : CustomRow
    {
        public double Factor { get; set; }

        public double Point { get; set; }

        public string Title { get; set; }

        public int Ordering { get; set; }

        public CustomWithPointRow(OfflineEntities.Odd oeOdd, int ViewTypeId)
        {
            this.Factor = oeOdd.Factor;
            this.Point = oeOdd.Point;
            this.ColumnIndex = oeOdd.ColumnIndex;
            this.Ordering = oeOdd.Ordering;
            this.ViewTypeId = ViewTypeId;
        }
    }
}
