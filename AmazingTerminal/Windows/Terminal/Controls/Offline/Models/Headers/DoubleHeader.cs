using AmazingTerminal.DataManagers.StaticDataManager;
using AmazingTerminal.DataManagers.TranslationsDataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;
using TranslationsEntities = AmazingTerminal.DataManagers.TranslationsDataManager.Entities;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers
{
    public class DoubleHeader : Header
    {
        public string Column1 { get; set; }

        public string Column2 { get; set; }

        public DoubleHeader(List<OfflineEntities.Odd> oeOdds, int ViewTypeId)
        {
            this.ViewTypeId = ViewTypeId;
            foreach (var oddsGroup in oeOdds.GroupBy(o => o.OddTypeId))
            {
                var odd = oddsGroup.FirstOrDefault();
                StaticEntities.OddType seOddType = new StaticEntities.OddType();
                var result = StaticManager.OddTypes.TryGetValue(odd.OddTypeId, out seOddType);
                if (result)
                {
                    TranslationsEntities.OddType teOddType = new TranslationsEntities.OddType();
                    result = TranslationsManager.OddTypes.TryGetValue(seOddType.Id, out teOddType);
                    if (result)
                    {
                        switch (seOddType.Ordering)
                        {
                            case 0:
                                Column1 = teOddType.Name;
                                break;
                            case 1:
                                Column2 = teOddType.Name;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        // NOT FOUND
                        switch (seOddType.Ordering)
                        {
                            case 0:
                                Column1 = seOddType.Name;
                                break;
                            case 1:
                                Column2 = seOddType.Name;
                                break;
                            default:
                                break;
                        }
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
