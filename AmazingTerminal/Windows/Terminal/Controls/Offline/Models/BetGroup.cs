using AmazingTerminal.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models
{
    public class BetGroup : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Ordering { get; set; }

        private ObservableCollection<BetType> _BetTypes;
        public ObservableCollection<BetType> BetTypes
        {
            get { return _BetTypes; }
            set
            {
                if (_BetTypes != value)
                {
                    _BetTypes = value;
                    RaisePropertyChanged("BetTypes");
                }
            }
        }

        private BetGroup()
        {
            BetTypes = new ObservableCollection<BetType>();
        }

        public BetGroup(int Id, string Name, int Ordering)
            : this()
        {
            this.Id = Id;
            this.Name = Name;
            this.Ordering = Ordering;
        }
    }
}
