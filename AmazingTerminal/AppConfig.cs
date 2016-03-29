using AmazingTerminal.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal
{
    public static class AppConfig
    {
        #region General Info
        public static string AppLanguage
        {
            get
            {
                var url = Settings.Default.AppLanguage;
                return url;
            }
        }

        public static bool IsLoginWindowRequires
        {
            get
            {
                var url = Settings.Default.LoginWindowRequires;
                return url;
            }
        }

        private static string APIHost
        {
            get
            {
                var url = Settings.Default.APIHost;
                return url;
            }
        }
        #endregion

        #region Translations Endpoints
        public static string SportsTranslationsEndpoint
        {
                        get
            {
            var url = string.Format(string.Format("{0}{1}",
                APIHost,
                string.Format(Settings.Default.SportsTranslationsEndpoint, Settings.Default.AppLanguage)));
            return url;
            }
        }

        public static string CountriesTranslationsEndpoint
        {
                        get
            {
            var url = string.Format(string.Format("{0}{1}",
                APIHost,
                string.Format(Settings.Default.CountriesTranslationsEndpoint, Settings.Default.AppLanguage)));
            return url;
            }
        }

        public static string LeaguesTranslationsEndpoint
        {
            get
            {
            var url = string.Format(string.Format("{0}{1}",
                APIHost,
                string.Format(Settings.Default.LeaguesTranslationsEndpoint, Settings.Default.AppLanguage)));
            return url;
            }
        }

        public static string TeamsTranslationsEndpoint
        {
                        get
            {
            var url = string.Format(string.Format("{0}{1}",
                APIHost,
                string.Format(Settings.Default.TeamsTranslationsEndpoint, Settings.Default.AppLanguage)));
            return url;
            }
        }

        public static string BetTypesTranslationsEndpoint
        {
                        get
            {
            var url = string.Format(string.Format("{0}{1}",
                APIHost,
                string.Format(Settings.Default.BetTypesTranslationsEndpoint, Settings.Default.AppLanguage)));
            return url;
            }
        }

        public static string BetGroupsTranslationsEndpoint
        {
                        get
            {
            var url = string.Format(string.Format("{0}{1}",
                APIHost,
                string.Format(Settings.Default.BetGroupsTranslationsEndpoint, Settings.Default.AppLanguage)));
            return url;
            }
        }

        public static string OddTypesTranslationsEndpoint
        {
            get
            {
                var url = string.Format(string.Format("{0}{1}",
                    APIHost,
                    string.Format(Settings.Default.OddTypesTranslationsEndpoint, Settings.Default.AppLanguage)));
                return url;
            }
        }
        #endregion

        #region Data Endpoints
        public static string GetSportsEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", Settings.Default.APIHost, Settings.Default.SportsEndpoint);
                return url;
            }
        }

        public static string GetLeaguesEndpointBySportId(int sportId)
        {
            var url = string.Format("{0}{1}", APIHost, string.Format(Settings.Default.LeaguesBySportIdEndpoint, sportId));
            return url;
        }

        public static string GetEventsEndpointByLeagueId(int leagueId)
        {
            var url = string.Format("{0}{1}", APIHost, string.Format(Settings.Default.EventsByLeagueIdEndpoint, leagueId));
            return url;
        }

        public static string GetEventsEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", APIHost, Settings.Default.EventsEndpoint);
                return url;
            }
        }

        public static string GetLeaguesEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", APIHost, Settings.Default.LeaguesEndpoint);
                return url;
            }
        }

        public static string BetTypesEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", APIHost, Settings.Default.BetTypesEndpoint);
                return url;
            }
        }

        public static string OddTypesEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", APIHost, Settings.Default.OddTypesEndpoint);
                return url;
            }
        }

        public static string ViewTypesEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", APIHost, Settings.Default.ViewTypesEndpoint);
                return url;
            }
        }

        public static string GetOddsByLeagueIdEndpoint(int leagueId)
        {
            var url = string.Format("{0}{1}", APIHost, string.Format(Settings.Default.OddsByLeagueId, leagueId));
            return url;
        }

        public static string GetOddsByEventIdEndpoint(int eventId)
        {
            var url = string.Format("{0}{1}", APIHost, string.Format(Settings.Default.OddsByEventId, eventId));
            return url;
        }

        public static string BetGroupsEndpoint
        {
            get
            {
                var url = string.Format("{0}{1}", APIHost, Settings.Default.BetGroupsEndpoind);
                return url;
            }
        }
        #endregion

        #region Logs Path

        public static string ErrorLogsPath
        {
            get
            {
                var path = Settings.Default.ErrorLogsPath;
                return path;
            }
        }

        #endregion
    }
}
