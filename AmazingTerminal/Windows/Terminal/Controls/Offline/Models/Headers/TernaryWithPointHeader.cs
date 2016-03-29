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
    public class TernaryWithPointHeader : Header
    {
        public string Column1 { get; set; }

        public string Column2 { get; set; }

        public string Column3 { get; set; }

        public string Column4 { get; set; }

        public string Column5 { get; set; }

        public string Column6 { get; set; }

        public string Column7 { get; set; }

        public TernaryWithPointHeader(List<OfflineEntities.Odd> oeOdds, int ViewTypeId)
        {
            this.ViewTypeId = ViewTypeId;
            Column4 = "OT";
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
                                switch (seOddType.ColumnIndex)
                                {
                                    case 1:
                                        Column1 = teOddType.Name;
                                        break;
                                    case 2:
                                        Column2 = teOddType.Name;
                                        break;
                                    case 3:
                                        Column3 = teOddType.Name;
                                        break;
                                }
                                break;
                            case 1:
                                switch (seOddType.ColumnIndex)
                                {
                                    case 1:
                                        Column5 = teOddType.Name;
                                        break;
                                    case 2:
                                        Column6 = teOddType.Name;
                                        break;
                                    case 3:
                                        Column7 = teOddType.Name;
                                        break;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    // STATIC ODDTYPE NOT FOUND
                    switch (seOddType.Ordering)
                    {

                    }
                }
            }
        }
    }
}
