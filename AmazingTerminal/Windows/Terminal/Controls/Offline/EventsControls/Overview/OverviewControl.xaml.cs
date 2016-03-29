using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.Overview
{
    /// <summary>
    /// Interaction logic for ShortEventsControl.xaml
    /// </summary>
    public partial class OverviewControl : UserControl
    {
        private static OverviewControl _Current;
        public static OverviewControl Current
        {
            get
            {
                if (_Current == null)
                    _Current = new OverviewControl();
                return _Current;
            }
        }

        public OverviewControl()
        {
            InitializeComponent();
            this.DataContext = OverviewControlViewModel.Current;
        }
    }
}
