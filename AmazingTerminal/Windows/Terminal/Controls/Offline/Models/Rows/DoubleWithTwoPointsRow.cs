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
    public class DoubleWithTwoPointsRow : CommonRow
    {
        public double F1 { get; set; }

        public double F2 { get; set; }

        public double P1 { get; set; }

        public double P2 { get; set; }

        public DoubleWithTwoPointsRow(List<OfflineEntities.Odd> oeOdds, int ViewTypeId)
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
                            F1 = odd.Factor;
                            P1 = odd.Point;
                            break;
                        case 1:
                            F2 = odd.Factor;
                            P2 = odd.Point;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // STATIC ODDTYPE NOT FOUND
                }
            }
        }
    }
}
