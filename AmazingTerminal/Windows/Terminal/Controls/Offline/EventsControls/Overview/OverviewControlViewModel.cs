using AmazingTerminal.DataManagers.DataLinkers;
using AmazingTerminal.DataManagers.OfflineDataManager;
using AmazingTerminal.DataManagers.StaticDataManager;
using AmazingTerminal.Misc;
using AmazingTerminal.Misc.Commands;
using AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.View;
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
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.Overview
{
    public class OverviewControlViewModel : BaseViewModel<OverviewControlViewModel>
    {
        private ObservableCollection<League> _Leagues = new ObservableCollection<League>();
        public ObservableCollection<League> Leagues
        {
            get { return _Leagues; }
            set
            {
                if (_Leagues != value)
                {
                    _Leagues = value;
                    RaisePropertyChanged("Leagues");
                }
            }
        }

        public OverviewControlViewModel()
        {
            Leagues = new ObservableCollection<League>();
            Leagues.CollectionChanged += LeaguesCollectionChanged;
        }

        async void LeaguesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
                return;

            var league = (League)e.NewItems[0];
            var odds = await OfflineManager.GetOddsByLeagueId(league.Id);
            var oddsGroupedByEvents = odds.GroupBy(o => o.EventId);
            foreach (var oddsOfEvent in oddsGroupedByEvents)
            {
                var currentEvent = league.Events.FirstOrDefault(evnt => evnt.Id == oddsOfEvent.FirstOrDefault().EventId);
                if (currentEvent == null)
                {
                    // ВРЕМЕННЫЙ КОСТЫЛЬ. Коллизия: на N событий из спортбука пришло одд для N+M событий 
                    continue;
                }
                var mainBetGroup = OfflineDataLinker.GetMainBetGroup(oddsOfEvent.ToList());
                currentEvent.BetGroups.Add(mainBetGroup);
                currentEvent.OddsCount = oddsOfEvent.Count();
            }
        }

        private ICommand _SelectEventCommand;
        public ICommand SelectEventCommand
        {
            get 
            {
                if (_SelectEventCommand == null)
                    _SelectEventCommand = new RelayCommandWithParameter(SelectEvent);
                return _SelectEventCommand;
            }
        }

        private void SelectEvent(object obj)
        {
            var evnt = obj as Event;
            if (evnt != null)
                SelectEvent(evnt);
        }

        private void SelectEvent(Event evnt)
        {
            OfflineControlViewModel.Current.ActiveControl = ViewControl.Current;
            ViewControlViewModel.Current.Event = evnt;
        }
    }
}
