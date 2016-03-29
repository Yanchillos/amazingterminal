using AmazingTerminal.Misc;
using AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.Overview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline
{
    public class OfflineControlViewModel : BaseViewModel<OfflineControlViewModel>
    {
        private object _ActiveControl;
        public object ActiveControl
        {
            get { return _ActiveControl; }
            set
            {
                if (_ActiveControl != value)
                {
                    _ActiveControl = value;
                    RaisePropertyChanged("ActiveControl");
                }
            }
        }

        public OfflineControlViewModel()
        {
            ActiveControl = OverviewControl.Current;
        }
    }
}
