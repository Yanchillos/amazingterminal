using AmazingTerminal.DataManagers.StaticDataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows
{
    public class TernaryWithPointRow : CommonRow
    {
        public double FHO { get; set; }

        public double FDO { get; set; }

        public double FGO { get; set; }

        public double Point { get; set; }

        public double FHU { get; set; }

        public double FDU { get; set; }

        public double FGU { get; set; }

        public TernaryWithPointRow(List<OfflineEntities.Odd> oeOdds, int ViewTypeId)
        {
            this.ViewTypeId = ViewTypeId;
            foreach (var odd in oeOdds)
            {
                StaticEntities.OddType oddType = new StaticEntities.OddType();
                var result = StaticManager.OddTypes.TryGetValue(odd.OddTypeId, out oddType);
                if (result)
                {
                    switch (oddType.Ordering)
                    {
                        case 0:
                            switch (oddType.ColumnIndex)
                            {
                                case 1:
                                    FHO = odd.Factor;
                                    break;
                                case 2:
                                    FDO = odd.Factor;
                                    break;
                                case 3:
                                    FGO = odd.Factor;
                                    break;
                            }
                            break;
                        case 1:
                            switch (oddType.ColumnIndex)
                            {
                                case 1:
                                    FHU = odd.Factor;
                                    break;
                                case 2:
                                    FDU = odd.Factor;
                                    break;
                                case 3:
                                    FGU = odd.Factor;
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    // STATIC ODDTYPE NOT FOUND
                }
            }
            Point = oeOdds[0].Point;
        }
    }
}
