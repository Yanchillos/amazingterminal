using AmazingTerminal.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Windows.Loading
{
    public class LoadingWindowViewModel : BaseViewModel<LoadingWindowViewModel>
    {
        private int _SportsCount;
        public int SportsCount
        {
            get { return _SportsCount; }
            set
            {
                if (_SportsCount != value)
                {
                    _SportsCount = value;
                    RaisePropertyChanged("SportsCount");
                }
            }
        }

        private int _LeaguesCount;
        public int LeaguesCount
        {
            get { return _LeaguesCount; }
            set
            {
                if (_LeaguesCount != value)
                {
                    _LeaguesCount = value;
                    RaisePropertyChanged("LeaguesCount");
                }
            }
        }

        private int _EventsCount;
        public int EventsCount
        {
            get { return _EventsCount; }
            set
            {
                if (_EventsCount != value)
                {
                    _EventsCount = value;
                    RaisePropertyChanged("EventsCount");
                }
            }
        }

        private int _BetTypesCount;
        public int BetTypesCount
        {
            get { return _BetTypesCount; }
            set
            {
                if (_BetTypesCount != value)
                {
                    _BetTypesCount = value;
                    RaisePropertyChanged("BetTypesCount");
                }
            }
        }

        private int _OddTypesCount;
        public int OddTypesCount
        {
            get { return _OddTypesCount; }
            set
            {
                if (_OddTypesCount != value)
                {
                    _OddTypesCount = value;
                    RaisePropertyChanged("OddTypesCount");
                }
            }
        }

        private int _ViewTypesCount;
        public int ViewTypesCount
        {
            get { return _ViewTypesCount; }
            set
            {
                if (_ViewTypesCount != value)
                {
                    _ViewTypesCount = value;
                    RaisePropertyChanged("ViewTypesCount");
                }
            }
        }

        private int _BetGroupsCount;
        public int BetGroupsCount
        {
            get { return _BetGroupsCount; }
            set
            {
                if (_BetGroupsCount != value)
                {
                    _BetGroupsCount = value;
                    RaisePropertyChanged("BetGroupsCount");
                }
            }
        }

        private int _TeamsTranslationsCount;
        public int TeamsTranslationsCount
        {
            get { return _TeamsTranslationsCount; }
            set
            {
                if (_TeamsTranslationsCount != value)
                {
                    _TeamsTranslationsCount = value;
                    RaisePropertyChanged("TeamsTranslationsCount");
                }
            }
        }

        private int _CountriesTranslationsCount;
        public int CountriesTranslationsCount
        {
            get { return _CountriesTranslationsCount; }
            set
            {
                if (_CountriesTranslationsCount != value)
                {
                    _CountriesTranslationsCount = value;
                    RaisePropertyChanged("CountriesTranslationsCount");
                }
            }
        }

        private int _LeaguesTranslationsCount;
        public int LeaguesTranslationsCount
        {
            get { return _LeaguesTranslationsCount; }
            set
            {
                if (_LeaguesTranslationsCount != value)
                {
                    _LeaguesTranslationsCount = value;
                    RaisePropertyChanged("LeaguesTranslationsCount");
                }
            }
        }

        private int _SportsTranslationsCount;
        public int SportsTranslationsCount
        {
            get { return _SportsTranslationsCount; }
            set
            {
                if (_SportsTranslationsCount != value)
                {
                    _SportsTranslationsCount = value;
                    RaisePropertyChanged("SportsTranslationsCount");
                }
            }
        }

        private int _BetGroupsTranslationsCount;
        public int BetGroupsTranslationsCount
        {
            get { return _BetGroupsTranslationsCount; }
            set
            {
                if (_BetGroupsTranslationsCount != value)
                {
                    _BetGroupsTranslationsCount = value;
                    RaisePropertyChanged("BetGroupsTranslationsCount");
                }
            }
        }

        private int _BetTypesTranslationsCount;
        public int BetTypesTranslationsCount
        {
            get { return _BetTypesTranslationsCount; }
            set
            {
                if (_BetTypesTranslationsCount != value)
                {
                    _BetTypesTranslationsCount = value;
                    RaisePropertyChanged("BetTypesTranslationsCount");
                }
            }
        }
    }
}
