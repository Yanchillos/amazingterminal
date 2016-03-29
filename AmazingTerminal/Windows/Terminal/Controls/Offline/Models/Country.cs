using AmazingTerminal.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int SportId { get; set; }

        private bool _IsOpen;
        public bool IsOpen
        {
            get { return _IsOpen; }
            set
            {
                if (_IsOpen != value)
                {
                    _IsOpen = value;
                    RaisePropertyChanged("IsOpen");
                }
            }
        }

        private ObservableCollection<League> _Leagues;
        public ObservableCollection<League> Leagues
        {
            get { return _Leagues; }
            set
            {
                if (_Leagues != value)
                {
                    _Leagues = value;
                    RaisePropertyChanged("Leagues");
                }
            }
        }

        private Country()
        {
            this.Leagues = new ObservableCollection<League>();
        }

        public Country(string Name, string Code, int SportId)
            : base()
        {
            this.Name = Name;
            this.Code = Code;
            this.SportId = SportId;
        }
    }
}
