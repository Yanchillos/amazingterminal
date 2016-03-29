using AmazingTerminal.DataManagers.DataLinkers;
using AmazingTerminal.DataManagers.OfflineDataManager;
using AmazingTerminal.Misc;
using AmazingTerminal.Misc.Commands;
using AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.Overview;
using AmazingTerminal.Windows.Terminal.Controls.Offline.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AmazingTerminal.Windows.Terminal.Controls.Offline.EventsControls.View
{
    public class ViewControlViewModel : BaseViewModel<ViewControlViewModel>
    {
        private Event _Event;
        public Event Event
        {
            get { return _Event; }
            set
            {
                if (_Event != value)
                {
                    _Event = value;
                    BuildFullEvent(_Event);
                    RaisePropertyChanged("Event");
                }
            }
        }

        private object _ActiveBetGroup;
        public object ActiveBetGroup
        {
            get { return _ActiveBetGroup; }
            set
            {
                if (_ActiveBetGroup != value)
                {
                    _ActiveBetGroup = value;
                    RaisePropertyChanged("ActiveBetGroup");
                }
            }
        }

        private ICommand _BackCommand;
        public ICommand BackCommand
        {
            get
            {
                if (_BackCommand == null)
                {
                    _BackCommand = new RelayCommand(Back);
                }
                return _BackCommand;
            }
        }

        private ICommand _BetGroupClickCommand;
        public ICommand BetGroupClickCommand
        {
            get
            {
                if (_BetGroupClickCommand == null)
                {
                    _BetGroupClickCommand = new RelayCommandWithParameter(BetGroupClick);
                }
                return _BetGroupClickCommand;
            }
        }

        private void Back()
        {
            OfflineControlViewModel.Current.ActiveControl = OverviewControl.Current;
        }

        private void BetGroupClick(object obj)
        {
            var clickedBetGroup = obj as BetGroup;
            if (clickedBetGroup != null)
                BetGroupClick(clickedBetGroup);
        }

        private void BetGroupClick(BetGroup clickedBetGroup)
        {
            ActivateBetGroup(clickedBetGroup);
        }

        private async void BuildFullEvent(Event evnt)
        {
            var odds = await OfflineManager.GetOddsByEventId(evnt.Id);
            var betGroups = OfflineDataLinker.GetBetGroups(odds.ToList());
            evnt.BetGroups = new ObservableCollection<BetGroup>(SortedBetGroups(betGroups));
            var mainBetGroup = evnt.BetGroups.FirstOrDefault(bg => bg.Id == 1);
            if (mainBetGroup != null)
                ActivateBetGroup(mainBetGroup);
        }

        private void ActivateBetGroup(BetGroup betGroup)
        {
            ActiveBetGroup = betGroup;
        }

        private List<BetGroup> SortedBetGroups(List<BetGroup> betGroups)
        {
            foreach (var betGroup in betGroups)
                betGroup.BetTypes = new ObservableCollection<BetType>(betGroup.BetTypes.OrderBy(bt => bt.Ordering));
            return betGroups;
        }
    }
}
