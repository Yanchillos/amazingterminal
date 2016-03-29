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

namespace AmazingTerminal.Windows.Terminal.Controls.History
{
    /// <summary>
    /// Interaction logic for HistoryControl.xaml
    /// </summary>
    public partial class HistoryControl : UserControl
    {
        private static HistoryControl _Current;
        public static HistoryControl Current
        {
            get
            {
                if (_Current == null)
                    _Current = new HistoryControl();
                return _Current;
            }
        }

        public HistoryControl()
        {
            InitializeComponent();
        }
    }
}
