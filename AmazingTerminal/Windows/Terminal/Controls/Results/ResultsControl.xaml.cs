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

namespace AmazingTerminal.Windows.Terminal.Controls.Results
{
    /// <summary>
    /// Interaction logic for ResultsControl.xaml
    /// </summary>
    public partial class ResultsControl : UserControl
    {
        private static ResultsControl _Current;
        public static ResultsControl Current
        {
            get
            {
                if (_Current == null)
                    _Current = new ResultsControl();
                return _Current;
            }
        }

        public ResultsControl()
        {
            InitializeComponent();
        }
    }
}
