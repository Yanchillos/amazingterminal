using AmazingTerminal.DataManagers.StaticDataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers
{
    public class DoubleWithTwoPointsHeader : Header
    {
        public string Column1 { get; set; }

        public string Column2 { get; set; }

        public string Column3 { get; set; }

        public string Column4 { get; set; }

        public DoubleWithTwoPointsHeader(List<OfflineEntities.Odd> oeOdds, int ViewTypeId)
        {
            this.ViewTypeId = ViewTypeId;
            Column2 = "Ф1";
            Column4 = "Ф2";
            foreach (var oddsGroup in oeOdds.GroupBy(o => o.OddTypeId))
            {
                var odd = oddsGroup.FirstOrDefault();
                StaticEntities.OddType oddType = new StaticEntities.OddType();
                var result = StaticManager.OddTypes.TryGetValue(odd.OddTypeId, out oddType);
                if (result)
                {
                    switch (oddType.Ordering)
                    {
                        case 0:
                            Column1 = oddType.Name;
                            break;
                        case 1:
                            Column3 = oddType.Name;
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
