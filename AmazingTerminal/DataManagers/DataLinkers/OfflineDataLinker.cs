using AmazingTerminal.DataManagers.TranslationsDataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LineEntities = AmazingTerminal.DataManagers.LineDataManager.Entities;
using OfflineEntities = AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using TranslationsEntities = AmazingTerminal.DataManagers.TranslationsDataManager.Entities;
using StaticEntities = AmazingTerminal.DataManagers.StaticDataManager.Entities;
using OfflineModels = AmazingTerminal.Windows.Terminal.Controls.Offline.Models;
using System.Diagnostics;
using AmazingTerminal.DataManagers.StaticDataManager;
using System.Collections.ObjectModel;

namespace AmazingTerminal.DataManagers.DataLinkers
{
    public static class OfflineDataLinker
    {
        public static List<OfflineModels.Event> ForgeSportbookEvents(List<OfflineEntities.Event> oeEvents)
        {
            List<OfflineModels.Event> events = new List<OfflineModels.Event>();
            foreach (var oeEvent in oeEvents)
            {
                TranslationsEntities.Team teTeam = new TranslationsEntities.Team();
                TranslationsEntities.Team teHome = new TranslationsEntities.Team();
                TranslationsEntities.Team teGuest = new TranslationsEntities.Team();

                if (!oeEvent.GuestId.HasValue || !oeEvent.HomeId.HasValue)
                {
                    // Long-term
                    continue;
                }

                var result = TranslationsManager.Teams.TryGetValue(oeEvent.HomeId.Value, out teTeam);
                if (result)
                {
                    teHome = teTeam;
                }
                else
                {
                    // TRANSLATION NOT FOUND
                }

                result = TranslationsManager.Teams.TryGetValue(oeEvent.GuestId.Value, out teTeam);
                if (result)
                {
                    teGuest = teTeam;
                }
                else
                {
                    // TRANSLATION NOT FOUND
                }
                events.Add(new OfflineModels.Event(oeEvent.Id, oeEvent.Code, oeEvent.HomeId.Value, oeEvent.GuestId.Value, teHome.Name, teGuest.Name, oeEvent.LeagueId));
            }
            return events;
        }

        public static List<OfflineModels.League> ForgeSportbookLeagues(List<LineEntities.League> leLeagues)
        {
            List<OfflineModels.League> leagues = new List<OfflineModels.League>();
            foreach (var leLeague in leLeagues)
            {
                TranslationsEntities.League teLeague = new TranslationsEntities.League();
                var result = TranslationsManager.Leagues.TryGetValue(leLeague.Id, out teLeague);
                if (result)
                    leagues.Add(new OfflineModels.League(leLeague.Id, teLeague.Name, leLeague.SportId, leLeague.CountryCode));
                else
                {
                    // TRANSLATION NOT FOUND
                }
            }
            return leagues;
        }

        public static List<OfflineModels.Sport> ForgeSportbookSports(List<LineEntities.Sport> leSports)
        {
            List<OfflineModels.Sport> sports = new List<OfflineModels.Sport>();
            foreach (var leSport in leSports)
            {
                TranslationsEntities.Sport teSport = new TranslationsEntities.Sport();
                var result = TranslationsManager.Sports.TryGetValue(leSport.Id, out teSport);
                if (result)
                    sports.Add(new OfflineModels.Sport(leSport.Id, teSport.Name, leSport.Ordering));
                else
                {
                    // TRANSLATION NOT FOUND
                }
            }
            return sports;
        }

        public static List<OfflineModels.Country> GetForgedSportbookCountries(List<LineEntities.League> leLeagues)
        {
            return ForgeSportbookCountries(leLeagues);
        }

        private static List<OfflineModels.Country> ForgeSportbookCountries(List<LineEntities.League> leLeagues)
        {
            List<OfflineModels.Country> countries = new List<OfflineModels.Country>();
            foreach (var leLeague in leLeagues)
            {
                TranslationsEntities.Country teCountry = new TranslationsEntities.Country();
                if (TranslationsManager.Countries.TryGetValue(leLeague.CountryCode, out teCountry))
                    countries.Add(new OfflineModels.Country(teCountry.Name, teCountry.Code, leLeague.SportId));
                else
                {
                    // TRANSLATION NOT FOUND
                }
            }
            return countries;
        }

        public static OfflineModels.BetGroup GetMainBetGroup(List<OfflineEntities.Odd> oeOdds)
        {
            var matchOdds = oeOdds.Where(o => o.BetTypeId == 1 || o.BetTypeId == 6).ToList();

            if (matchOdds.Count == 0)
                return null;

            var seBetGroup = new StaticEntities.BetGroup();
            var result = StaticManager.BetGroups.TryGetValue(1, out seBetGroup);
            if (!result)
            {
                // STATIC BETGROUP NOT FOUND
                return null;
            }
            var seBetType = new StaticEntities.BetType();
            result = StaticManager.BetTypes.TryGetValue(matchOdds[0].BetTypeId, out seBetType);
            if (!result)
            {
                // STATIC BETTYPE NOT FOUND
                return null;
            }
            OfflineModels.BetGroup mainBetGroup = new OfflineModels.BetGroup(1, TranslationsManager.BetGroups.FirstOrDefault().Value.Name, seBetGroup.Ordering);
            OfflineModels.BetType matchBetType = new OfflineModels.BetType(1, TranslationsManager.BetTypes.FirstOrDefault().Value.Name, seBetType.Ordering, seBetType.ColumnsCount, oeOdds.Where(o => o.BetTypeId == 1 || o.BetTypeId == 6).ToList());
            mainBetGroup.BetTypes.Add(matchBetType);
            return mainBetGroup;
        }

        public static List<OfflineModels.BetGroup> GetBetGroups(List<OfflineEntities.Odd> oeOdds)
        {
            List<OfflineModels.BetGroup> betGroups = new List<OfflineModels.BetGroup>();
            var oddsGroupedByBetTypeId = oeOdds.GroupBy(o => o.BetTypeId);
            foreach (var oddsOfBetType in oddsGroupedByBetTypeId)
            {
                TranslationsEntities.BetType teBetType = new TranslationsEntities.BetType();
                var result = TranslationsManager.BetTypes.TryGetValue(oddsOfBetType.Key, out teBetType);
                if (result)
                {
                    StaticEntities.BetType seBetType = new StaticEntities.BetType();
                    result = StaticManager.BetTypes.TryGetValue(teBetType.Id, out seBetType);
                    if (result)
                    {
                        OfflineModels.BetType betType = new OfflineModels.BetType(oddsOfBetType.Key, teBetType.Name, seBetType.Ordering, seBetType.ColumnsCount, oddsOfBetType.ToList());
                        var betGroup = betGroups.FirstOrDefault(bg => bg.Id == seBetType.BetGroupId);
                        if (betGroup == null)
                        {
                            TranslationsEntities.BetGroup teBetGroup = new TranslationsEntities.BetGroup();
                            result = TranslationsManager.BetGroups.TryGetValue(seBetType.BetGroupId, out teBetGroup);
                            if (result)
                            {
                                var seBetGroup = new StaticEntities.BetGroup();
                                result = StaticManager.BetGroups.TryGetValue(teBetGroup.Id, out seBetGroup);
                                if (result)
                                {
                                    OfflineModels.BetGroup newBetGroup = new OfflineModels.BetGroup(teBetGroup.Id, teBetGroup.Name, seBetGroup.Ordering);
                                    newBetGroup.BetTypes.Add(betType);
                                    betGroups.Add(newBetGroup);
                                }
                                else
                                {
                                    // STATIC BETGROUP NOT FOUND
                                    continue;
                                }
                            }
                            else
                            {
                                // BETGROUP TRANSLATION NOT FOUND
                                continue;
                            }
                        }
                        else
                        {
                            betGroup.BetTypes.Add(betType);
                        }
                    }
                    else
                    {
                        // BETTYPE TRANSLATION NOT FOUNT
                        continue;
                    }
                }
                else
                {
                    // STATIC BETTYPE NOT FOUNT
                    continue;
                }
            }
            return betGroups;
        }
    }
}
