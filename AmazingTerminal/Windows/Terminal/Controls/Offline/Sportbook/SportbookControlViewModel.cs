using AmazingTerminal.Misc;
using AmazingTerminal.Misc.Commands;
using AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.Overview;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.Sportbook
{
    public class SportbookControlViewModel : BaseViewModel<SportbookControlViewModel>
    {
        private ObservableCollection<Sport> _Sports = new ObservableCollection<Sport>();
        public ObservableCollection<Sport> Sports
        {
            get { return _Sports; }
            set
            {
                if (_Sports != value)
                {
                    _Sports = value;
                    RaisePropertyChanged("Sports");
                }
            }
        }

        public ObservableCollection<League> SelectedLeagues { get; set; }

        public SportbookControlViewModel()
        {
            SelectedLeagues = new ObservableCollection<League>();
            SelectedLeagues.CollectionChanged += SelectedLeaguesCollectionChanged;
        }

        private ICommand _SportUIActionCommand;
        public ICommand SportUIActionCommand
        {
            get
            {
                if (_SportUIActionCommand == null)
                    _SportUIActionCommand = new RelayCommandWithParameter(SportUIAction);
                return _SportUIActionCommand;
            }
        }

        private void SportUIAction(object obj)
        {
            var sport = obj as Sport;
            if (sport != null)
                SportUIAction(sport);
        }

        private void SportUIAction(Sport sport)
        {
            sport.IsOpen = !sport.IsOpen;
        }

        private ICommand _CountryUIActionCommand;
        public ICommand CountryUIActionCommand
        {
            get
            {
                if (_CountryUIActionCommand == null)
                    _CountryUIActionCommand = new RelayCommandWithParameter(CountryUIAction);
                return _CountryUIActionCommand;
            }
        }

        private void CountryUIAction(object obj)
        {
            var country = obj as Country;
            if (country != null)
                CountryUIAction(country);
        }

        private void CountryUIAction(Country country)
        {
            country.IsOpen = !country.IsOpen;
        }

        private ICommand _LeagueUIActionCommand;
        public ICommand LeagueUIActionCommand
        {
            get
            {
                if (_LeagueUIActionCommand == null)
                    _LeagueUIActionCommand = new RelayCommandWithParameter(LeagueUIAction);
                return _LeagueUIActionCommand;
            }
        }

        private void LeagueUIAction(object obj)
        {
            var league = obj as League;
            if (league != null)
                LeagueUIAction(league);
        }

        private void LeagueUIAction(League league)
        {
            league.IsSelected = !league.IsSelected;
        }

        private ICommand _LeagueCheckedCommand;
        public ICommand LeagueCheckedCommand
        {
            get
            {
                if (_LeagueCheckedCommand == null)
                    _LeagueCheckedCommand = new RelayCommandWithParameter(LeagueChecked);
                return _LeagueCheckedCommand;
            }
        }

        private void LeagueChecked(object obj)
        {
            var league = obj as League;
            if (league != null)
                LeagueChecked(league);
        }

        private void LeagueChecked(League league)
        {
            SelectedLeagues.Add(league);
        }

        private ICommand _LeagueUncheckedCommand;
        public ICommand LeagueUncheckedCommand
        {
            get
            {
                if (_LeagueUncheckedCommand == null)
                    _LeagueUncheckedCommand = new RelayCommandWithParameter(LeagueUnchecked);
                return _LeagueUncheckedCommand;
            }
        }

        private void LeagueUnchecked(object obj)
        {
            var league = obj as League;
            if (league != null)
                LeagueUnchecked(league);
        }

        private void LeagueUnchecked(League league)
        {
            SelectedLeagues.Remove(league);
        }

        private void SelectedLeaguesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var league = (League)e.NewItems[0];
                OverviewControlViewModel.Current.Leagues.Add(league);
            }
            else
            {
                var league = (League)e.OldItems[0];
                OverviewControlViewModel.Current.Leagues.Remove(league);
            }
        }
    }
}
