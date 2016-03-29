using AmazingTerminal.Misc;
using AmazingTerminal.Misc.Commands;
using AmazingTerminal.Windows.Terminal.Controls.History;
using AmazingTerminal.Windows.Terminal.Controls.Live;
using AmazingTerminal.Windows.Terminal.Controls.Offline;
using AmazingTerminal.Windows.Terminal.Controls.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AmazingTerminal.Windows.Terminal.Controls.Menu
{
    public class MenuControlViewModel : BaseViewModel<MenuControlViewModel>
    {
        private ICommand _SwitchControlCommand;
        public ICommand SwitchControlCommand
        {
            get
            {
                if (_SwitchControlCommand == null)
                    _SwitchControlCommand = new RelayCommandWithParameter(SwitchControl);
                return _SwitchControlCommand;
            }
        }

        private void SwitchControl(object obj)
        {
            var controlName = obj as string;
            if (controlName != null)
                SwitchControl(controlName);
        }

        private void SwitchControl(string controlName)
        {
            var type = (ControlType)Enum.Parse(typeof(ControlType), controlName, true);
            switch (type)
            {
                case ControlType.Offline:
                    TerminalWindowViewModel.Current.ActiveControl = OfflineControl.Current;
                    break;
                case ControlType.Live:
                    TerminalWindowViewModel.Current.ActiveControl = LiveControl.Current;
                    break;
                case ControlType.History:
                    TerminalWindowViewModel.Current.ActiveControl = HistoryControl.Current;
                    break;
                case ControlType.Results:
                    TerminalWindowViewModel.Current.ActiveControl = ResultsControl.Current;
                    break;
            }
        }
    }

    public enum ControlType
    {
        Offline,
        Live,
        History,
        Results
    }
}
