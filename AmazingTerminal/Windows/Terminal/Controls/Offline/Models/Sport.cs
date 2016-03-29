using AmazingTerminal.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Models
{
    public class Sport : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Ordering { get; set; }

        private ObservableCollection<Country> _Countries;
        public ObservableCollection<Country> Countries
        {
            get { return _Countries; }
            set
            {
                if (_Countries != value)
                {
                    _Countries = value;
                    RaisePropertyChanged("Countries");
                }
            }
        }

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

        private Sport()
        {
            this.Countries = new ObservableCollection<Country>();
        }

        public Sport(int Id, string Name, int Ordering)
            : base()
        {
            this.Id = Id;
            this.Name = Name;
            this.Ordering = Ordering;
        }
    }
}
