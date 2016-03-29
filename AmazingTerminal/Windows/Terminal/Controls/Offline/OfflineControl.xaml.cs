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

namespace AmazingTerminal.Windows.Terminal.Controls.Offline
{
    /// <summary>
    /// Interaction logic for OfflineControl.xaml
    /// </summary>
    public partial class OfflineControl : UserControl
    {
        private static OfflineControl _Current;
        public static OfflineControl Current
        {
            get
            {
                if (_Current == null)
                    _Current = new OfflineControl();
                return _Current;
            }
        }

        public OfflineControl()
        {
            InitializeComponent();
            this.DataContext = OfflineControlViewModel.Current;
        }
    }
}
