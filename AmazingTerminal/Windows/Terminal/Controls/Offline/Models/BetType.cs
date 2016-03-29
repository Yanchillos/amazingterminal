using AmazingTerminal.DataManagers.StaticDataManager;
using AmazingTerminal.Misc;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models
{
    public class BetType : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCustom { get; set; }

        public int ColumnsCount { get; set; }

        public int Ordering { get; set; }

        private ObservableCollection<Row> _Rows;
        public ObservableCollection<Row> Rows
        {
            get { return _Rows; }
            set
            {
                if (_Rows != value)
                {
                    _Rows = value;
                    RaisePropertyChanged("Rows");
                }
            }
        }

        public Header Header { get; set; }

        private BetType()
        {
            Rows = new ObservableCollection<Row>();
        }

        public BetType(int Id, string Name, int Ordering, int ColumnsCount, List<OfflineEntities.Odd> oeOdds)
            : this()
        {
            this.Id = Id;
            this.Name = Name;
            this.Ordering = Ordering;
            this.ColumnsCount = ColumnsCount;
            this.Header = ForgeHeader(oeOdds);
            this.Rows = new ObservableCollection<Row>(ForgeRows(oeOdds));
        }

        private Header ForgeHeader(List<OfflineEntities.Odd> oeOdds)
        {
            Header header = new Header();
            StaticEntities.BetType betType = new StaticEntities.BetType();
            var result = StaticManager.BetTypes.TryGetValue(oeOdds.FirstOrDefault().BetTypeId, out betType);
            if (result)
            {
                StaticEntities.ViewType viewType = new StaticEntities.ViewType();
                result = StaticManager.ViewTypes.TryGetValue(betType.ViewTypeId, out viewType);
                if (result)
                {
                    switch (viewType.Id)
                    {
                        case 1:
                            header = new DoubleHeader(oeOdds, viewType.Id);
                            break;
                        case 2:
                            header = new TernaryHeader(oeOdds, viewType.Id);
                            break;
                        case 3:
                            header = new DoubleWithTwoPointsHeader(oeOdds, viewType.Id);
                            break;
                        case 12:
                            header = new DoubleWithPointHeader(oeOdds, viewType.Id);
                            break;
                        case 16:
                            header = new TernaryWithPointHeader(oeOdds, viewType.Id);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // STATIC VIEWTYPE NOT FOUND
                    return null;
                }
            }
            else
            {
                // STATIC BETTYPE NOT FOUND
                return null;
            }
            return header;
        }

        private List<Row> ForgeRows(List<OfflineEntities.Odd> oeOdds)
        {
            List<Row> rows = new List<Row>();
            StaticEntities.BetType betType = new StaticEntities.BetType();
            var result = StaticManager.BetTypes.TryGetValue(oeOdds.FirstOrDefault().BetTypeId, out betType);
            if (result)
            {
                StaticEntities.ViewType viewType = new StaticEntities.ViewType();
                result = StaticManager.ViewTypes.TryGetValue(betType.ViewTypeId, out viewType);
                if (result)
                {
                    switch (viewType.Id)
                    {
                        case 1:
                            rows.Add(new DoubleRow(oeOdds, viewType.Id));
                            break;
                        case 2:
                            rows.Add(new TernaryRow(oeOdds, viewType.Id));
                            break;
                        case 3:
                            foreach (var oddsGroupedByPoint in oeOdds.GroupBy(o => Math.Abs(o.Point)))
                            {
                                rows.Add(new DoubleWithTwoPointsRow(oddsGroupedByPoint.ToList(), viewType.Id));
                            }
                            break;
                        case 5:
                        case 6:
                        case 7:
                            foreach (var oeOdd in oeOdds)
                            {
                                rows.Add(new CustomSimpleRow(oeOdd, viewType.Id));
                            }
                            this.IsCustom = true;
                            NormolizeCustomRowsAndBetType(rows);
                            break;
                        case 12:
                            foreach (var oddsGroupedByPoint in oeOdds.GroupBy(o => Math.Abs(o.Point)))
                            {
                                rows.Add(new DoubleWithPointRow(oddsGroupedByPoint.ToList(), viewType.Id));
                            }
                            break;
                        case 16:
                            foreach (var oddsGroupedByPoint in oeOdds.GroupBy(o => Math.Abs(o.Point)))
                            {
                                rows.Add(new TernaryWithPointRow(oddsGroupedByPoint.ToList(), viewType.Id));
                            }
                            break;
                        case 17:
                            foreach (var oeOdd in oeOdds)
                            {
                                rows.Add(new CustomWithPointRow(oeOdd, viewType.Id));
                            }
                            this.IsCustom = true;
                            NormolizeCustomRowsAndBetType(rows);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // STATIC VIEWTYPE NOT FOUND
                    return null;
                }
            }
            else
            {
                // STATIC BETTYPE NOT FOUND
                return null;
            }
            return rows;
        }

        private void NormolizeCustomRowsAndBetType(List<Row> rows)
        {
            var customRows = rows.Cast<CustomRow>().ToList();
            var minIndex = customRows.Min(r => r.ColumnIndex);
            var maxIndex = customRows.Max(r => r.ColumnIndex);
            var middleRow = customRows.FirstOrDefault(r => r.ColumnIndex == maxIndex - 1);
            if (middleRow == null)
            {
                customRows.Where(r => r.ColumnIndex == maxIndex).ToList().ForEach(r =>
                {
                    r.ColumnIndex = minIndex + 1;
                });
                maxIndex = minIndex + 1;
            }
            if (minIndex != 0)
            {
                maxIndex = maxIndex - minIndex;
                customRows.ToList().ForEach(r =>
                {
                    r.ColumnIndex = r.ColumnIndex - minIndex;
                });
                minIndex = 0;
            }
            if (this.ColumnsCount != maxIndex + 1)
            {
                this.ColumnsCount = maxIndex + 1;
            }
        }

        public List<CustomRow> GetCustomColumn1Rows
        {
            get
            {
                var customRows = this.Rows.Cast<CustomRow>().Where(r => r.ColumnIndex == 0).ToList();
                return customRows;
            }
        }

        public List<CustomRow> GetCustomColumn2Rows
        {
            get
            {
                var customRows = this.Rows.Cast<CustomRow>().Where(r => r.ColumnIndex == 1).ToList();
                return customRows;
            }
        }

        public List<CustomRow> GetCustomColumn3Rows
        {
            get
            {
                var customRows = this.Rows.Cast<CustomRow>().Where(r => r.ColumnIndex == 2).ToList();
                return customRows;
            }
        }
    }
}
