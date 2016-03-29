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

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.View
{
    /// <summary>
    /// Interaction logic for ViewControl.xaml
    /// </summary>
    public partial class ViewControl : UserControl
    {
        private static ViewControl _Current;
        public static ViewControl Current
        {
            get
            {
                if (_Current == null)
                    _Current = new ViewControl();
                return _Current;
            }
        }

        public ViewControl()
        {
            InitializeComponent();
            this.DataContext = ViewControlViewModel.Current;
        }
    }
}
