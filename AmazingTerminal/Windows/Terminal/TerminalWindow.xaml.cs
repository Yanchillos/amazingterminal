using AmazingTerminal.DataManagers.DataLinkers;
using AmazingTerminal.DataManagers.OfflineDataManager;
using AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using AmazingTerminal.DataManagers.LineDataManager;
using AmazingTerminal.Windows.Loading;
using AmazingTerminal.Windows.Terminal.Controls.Offline;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Sportbook;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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

using LineEntities = AmazingTerminal.DataManagers.LineDataManager.Entities;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using TranslationsEntities = AmazingTerminal.DataManagers.TranslationsDataManager.Entities;
using OfflineModels = AmazingTerminal.Windows.Terminal.Controls.Offline.Models;
using AmazingTerminal.DataManagers;
using System.Collections.ObjectModel;

namespace AmazingTerminal.Windows.Terminal
{
    /// <summary>
    /// Interaction logic for TerminalWindow.xaml
    /// </summary>
    public partial class TerminalWindow : Window
    {
        private static TerminalWindow _Current;
        public static TerminalWindow Current
        {
            get
            {
                if (_Current == null)
                    _Current = new TerminalWindow();
                return _Current;
            }
        }

        public TerminalWindow()
        {
            InitializeComponent();
            this.DataContext = TerminalWindowViewModel.Current;
        }

        public override void BeginInit()
        {
            base.BeginInit();
            InitializeTerminal();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            TerminalWindowViewModel.Current.ActiveControl = OfflineControl.Current;
        }

        private void InitializeTerminal()
        {
            LoadingWindow.Current.ShowDialog();
            InitializeOfflineSportbook();
        }

        private void InitializeOfflineSportbook()
        {
            // Все требуемые данные
            var oeActualEvents = OfflineManager.Events;
            var oeAllLeagues = LineManager.Leagues;
            var oeAllSports = LineManager.Sports;
            var forgedEvents = OfflineDataLinker.ForgeSportbookEvents(oeActualEvents.Values.ToList());

            // Сборка актуальных лиг
            var actualLeaguesIds = oeActualEvents.Select(e => e.Value.LeagueId).Distinct().ToList<int>();
            var oeActualLeagues = new ConcurrentDictionary<int, LineEntities.League>(oeAllLeagues.Where(l => actualLeaguesIds.Contains(l.Value.Id)));
            var forgedLeagues = OfflineDataLinker.ForgeSportbookLeagues(oeActualLeagues.Values.ToList());

            // Сборка актуальных спортов
            var actualSportsIds = oeActualLeagues.Select(l => l.Value.SportId).Distinct().ToList<int>();
            var oeActualSports = new ConcurrentDictionary<int, LineEntities.Sport>(oeAllSports.Where(s => actualSportsIds.Contains(s.Value.Id)));
            var forgedSports = OfflineDataLinker.ForgeSportbookSports(oeActualSports.Values.ToList());

            // Сборка актуальных стран
            var forgedCountries = OfflineDataLinker.GetForgedSportbookCountries(oeActualLeagues.Values.ToList());

            // Заполнение коллекций моделей
            forgedSports.ForEach(sport =>
                {
                    var countries = forgedCountries.Where(c => c.SportId == sport.Id).GroupBy(c => c.Code).Select(g => g.FirstOrDefault()).OrderBy(c => c.Name).ToList<OfflineModels.Country>();
                    countries.ForEach(country =>
                        {
                            var leagues = forgedLeagues.Where(l => l.SportId == sport.Id && l.CountryCode == country.Code).OrderBy(l => l.Name).ToList<OfflineModels.League>();
                            leagues.ForEach(league =>
                                {
                                    var events = forgedEvents.Where(e => e.LeagueId == league.Id).ToList<OfflineModels.Event>();
                                    league.Events = new ObservableCollection<OfflineModels.Event>(events);
                                });
                            country.Leagues = new ObservableCollection<OfflineModels.League>(leagues);
                        });
                    sport.Countries = new ObservableCollection<OfflineModels.Country>(countries);
                });

            // Updating View
            SportbookControlViewModel.Current.Sports = new ObservableCollection<OfflineModels.Sport>(forgedSports.OrderBy(s => s.Ordering));
        }
    }
}
