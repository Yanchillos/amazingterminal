using AmazingTerminal.Misc;
using AmazingTerminal.Windows.Terminal.Controls.Offline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Terminal
{
    public class TerminalWindowViewModel : BaseViewModel<TerminalWindowViewModel>
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
    }
}
