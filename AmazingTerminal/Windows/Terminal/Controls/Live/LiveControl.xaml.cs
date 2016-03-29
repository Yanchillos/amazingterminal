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

namespace AmazingTerminal.Windows.Terminal.Controls.Live
{
    /// <summary>
    /// Interaction logic for LiveControl.xaml
    /// </summary>
    public partial class LiveControl : UserControl
    {
        private static LiveControl _Current;
        public static LiveControl Current
        {
            get
            {
                if (_Current == null)
                    _Current = new LiveControl();
                return _Current;
            }
        }

        public LiveControl()
        {
            InitializeComponent();
        }
    }
}
