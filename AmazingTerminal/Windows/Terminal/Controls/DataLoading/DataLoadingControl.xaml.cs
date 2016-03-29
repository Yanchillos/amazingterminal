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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmazingTerminal.Windows.Terminal.Controls.DataLoading
{
    /// <summary>
    /// Interaction logic for DataLoadingControl.xaml
    /// </summary>
    public partial class DataLoadingControl : UserControl
    {
        public DataLoadingControl()
        {
            this.InitializeComponent();
            this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(DataLoadingControl_IsVisibleChanged);
        }

        private void DataLoadingControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Storyboard __storyboard = this.FindResource("canvasAnimation") as Storyboard;
            if ((bool)e.NewValue)
                __storyboard.Begin(this.canvas, true);
            else
                __storyboard.Remove(this.canvas);
        }
    }
}
