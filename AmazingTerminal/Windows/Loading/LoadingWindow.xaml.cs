using AmazingTerminal.DataManagers;
using AmazingTerminal.DataManagers.LineDataManager;
using AmazingTerminal.DataManagers.OfflineDataManager;
using AmazingTerminal.DataManagers.StaticDataManager;
using AmazingTerminal.DataManagers.TranslationsDataManager;
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
using System.Windows.Shapes;

namespace AmazingTerminal.Windows.Loading
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private static LoadingWindow _Current;
        public static LoadingWindow Current
        {
            get
            {
                if (_Current == null)
                    _Current = new LoadingWindow();
                return _Current;
            }
        }

        public LoadingWindow()
        {
            InitializeComponent();
            this.DataContext = LoadingWindowViewModel.Current;
        }

        protected async override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            await Task.Run(() => InitializeTerminalData());
            DialogResult = true;
            this.Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!DialogResult.HasValue)
                Application.Current.Shutdown();
        }

        private void InitializeTerminalData()
        {
            List<Task> tasks = new List<Task>()
            {
                InitializeSportsTranslations(),
                InitializeCountriesTranslations(),
                InitializeLeaguesTranslations(),
                InitializeTeamsTranslations(),
                InitializeBetGroupsTranslations(),
                InitializeBetTypesTranslations(),
                InitializeOddTypesTranslations(),
                InitializeSports(),
                InitializeLeagues(),
                InitializeEvents(),
                InitializeBetTypes(),
                InitializeOddTypes(),
                InitializeViewTypes(),
                InitializeBetGroups()
            };
            Task.WaitAll(tasks.ToArray());
        }

        #region Line Data
        private async Task InitializeSports()
        {
            var task = await LineManager.InitializeSports();
            LoadingWindowViewModel.Current.SportsCount = task;
        }

        private async Task InitializeLeagues()
        {
            var task = await LineManager.InitializeLeagues();
            LoadingWindowViewModel.Current.LeaguesCount = task;
        }
        #endregion

        #region Offline Data
        private async Task InitializeEvents()
        {
            var task = await OfflineManager.InitializeEvents();
            LoadingWindowViewModel.Current.EventsCount = task;
        }
        #endregion

        #region Translations Data
        private async Task InitializeSportsTranslations()
        {
            var task = await TranslationsManager.InitializeSportsTranslations();
            LoadingWindowViewModel.Current.SportsTranslationsCount = task;
        }

        private async Task InitializeCountriesTranslations()
        {
            var task = await TranslationsManager.InitializeCountriesTranslations();
            LoadingWindowViewModel.Current.CountriesTranslationsCount = task;
        }

        private async Task InitializeLeaguesTranslations()
        {
            var task = await TranslationsManager.InitializeLeaguesTranslations();
            LoadingWindowViewModel.Current.LeaguesTranslationsCount = task;
        }

        private async Task InitializeTeamsTranslations()
        {
            var task = await TranslationsManager.InitializeTeamsTranslations();
            LoadingWindowViewModel.Current.TeamsTranslationsCount = task;
        }

        private async Task InitializeBetGroupsTranslations()
        {
            var task = await TranslationsManager.InitializeBetGroupsTranslations();
            LoadingWindowViewModel.Current.BetGroupsTranslationsCount = task;
        }

        private async Task InitializeBetTypesTranslations()
        {
            var task = await TranslationsManager.InitializeBetTypesTranslations();
            LoadingWindowViewModel.Current.BetTypesTranslationsCount = task;
        }

        private async Task InitializeOddTypesTranslations()
        {
            var task = await TranslationsManager.InitializeOddTypesTranslations();
            //LoadingWindowViewModel.Current.BetTypesTranslationsCount = task;
            var a = task;
        }
        #endregion

        #region Static Data
        private async Task InitializeBetTypes()
        {
            var task = await StaticManager.InitializeBetTypes();
            LoadingWindowViewModel.Current.BetTypesCount = task;
        }

        private async Task InitializeOddTypes()
        {
            var task = await StaticManager.InitializeOddTypes();
            LoadingWindowViewModel.Current.OddTypesCount = task;
        }

        private async Task InitializeViewTypes()
        {
            var task = await StaticManager.InitializeViewTypes();
            LoadingWindowViewModel.Current.ViewTypesCount = task;
        }

        private async Task InitializeBetGroups()
        {
            var task = await StaticManager.InitializeBetGroups();
            LoadingWindowViewModel.Current.BetGroupsCount = task;
        }
        #endregion
    }
}
