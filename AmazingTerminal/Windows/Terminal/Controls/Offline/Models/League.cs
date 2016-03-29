using AmazingTerminal.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models
{
    public class League : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SportId { get; set; }

        public string CountryCode { get; set; }

        private ObservableCollection<Event> _Events;
        public ObservableCollection<Event> Events
        {
            get { return _Events; }
            set
            {
                if (_Events != value)
                {
                    _Events = value;
                    RaisePropertyChanged("Events");
                }
            }
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        private League()
        {
            this.Events = new ObservableCollection<Event>();
        }

        public League(int Id, string Name, int SportId, string CountryCode)
            : base()
        {
            this.Id = Id;
            this.Name = Name;
            this.SportId = SportId;
            this.CountryCode = CountryCode;
        }
    }
}
