using AmazingTerminal.Windows.Login;
using AmazingTerminal.Windows.Terminal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AmazingTerminal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            if (AppConfig.IsLoginWindowRequires)
                LoginWindow.Current.Show();
            else
            {
                TerminalWindow.Current.Show();
            }
        }
    }
}
