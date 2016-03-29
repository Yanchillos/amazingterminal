using AmazingTerminal.Misc;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Headers;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Models.Rows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models
{
    public class Event : BaseModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int HomeId { get; set; }

        public int GuestId { get; set; }

        public string HomeName { get; set; }

        public string GuestName { get; set; }

        public string EventName
        {
            get
            {
                return string.Format("{0} - {1}", HomeName, GuestName);
            }
        }

        public int LeagueId { get; set; }

        private int _OddsCount;
        public int OddsCount
        {
            get { return _OddsCount; }
            set
            {
                if (_OddsCount != value)
                {
                    _OddsCount = value;
                    RaisePropertyChanged("OddsCount");
                }
            }
        }

        private ObservableCollection<BetGroup> _BetGroups;
        public ObservableCollection<BetGroup> BetGroups
        {
            get { return _BetGroups; }
            set
            {
                if (_BetGroups != value)
                {
                    _BetGroups = value;
                    RaisePropertyChanged("BetGroups");
                }
            }
        }

        public Header MainBetGroupHeader
        {
            get
            {
                var mainBetGroup = BetGroups.FirstOrDefault(bg => bg.Id == 1);
                if (mainBetGroup != null)
                {
                    var matchBetType = mainBetGroup.BetTypes.FirstOrDefault(bt => bt.Id == 1 || bt.Id == 6);
                    return matchBetType.Header;
                }
                return null;
            }
        }

        public Row MainBetTypeRow
        {
            get
            {
                var mainBetGroup = BetGroups.FirstOrDefault(bg => bg.Id == 1);
                if (mainBetGroup != null)
                {
                    var matchBetType = mainBetGroup.BetTypes.FirstOrDefault(bt => bt.Id == 1 || bt.Id == 6);
                    return matchBetType.Rows[0];
                }
                return null;
            }
        }

        public Event()
        {
            this.BetGroups = new ObservableCollection<BetGroup>();
            this.BetGroups.CollectionChanged += BetGroupsCollectionChanged;
        }

        public Event(int Id, string Code, int HomeId, int GuestId, string HomeName, string GuestName, int LeagueId)
            : this()
        {
            this.Id = Id;
            this.Code = Code;
            this.HomeId = HomeId;
            this.GuestId = GuestId;
            this.HomeName = HomeName;
            this.GuestName = GuestName;
            this.LeagueId = LeagueId;
        }

        private void BetGroupsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("MainBetGroupHeader");
            RaisePropertyChanged("MainBetTypeRow");
        }
    }
}
