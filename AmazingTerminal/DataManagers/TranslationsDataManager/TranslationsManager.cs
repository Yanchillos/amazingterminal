using AmazingTerminal.DataManagers.TranslationsDataManager.Entities;
using AmazingTerminal.Misc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.TranslationsDataManager
{
    public static class TranslationsManager
    {
        public static ConcurrentDictionary<int, Sport> Sports { get; private set; }
        public static ConcurrentDictionary<string, Country> Countries { get; private set; }
        public static ConcurrentDictionary<int, League> Leagues { get; private set; }
        public static ConcurrentDictionary<int, Team> Teams { get; private set; }
        public static ConcurrentDictionary<int, BetGroup> BetGroups { get; private set; }
        public static ConcurrentDictionary<int, BetType> BetTypes { get; private set; }
        public static ConcurrentDictionary<int, OddType> OddTypes { get; private set; }

        static TranslationsManager()
        {
            Sports = new ConcurrentDictionary<int, Sport>();
            Countries = new ConcurrentDictionary<string, Country>();
            Leagues = new ConcurrentDictionary<int, League>();
            Teams = new ConcurrentDictionary<int, Team>();
            BetGroups = new ConcurrentDictionary<int, BetGroup>();
            BetTypes = new ConcurrentDictionary<int, BetType>();
            OddTypes = new ConcurrentDictionary<int, OddType>();
        }

        public async static Task<int> InitializeSportsTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Sport>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.SportsTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<Sport>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var sport in parsedResponse.Items)
                                Sports.GetOrAdd(sport.Id, sport);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return Sports.Count;
        }

        public async static Task<int> InitializeCountriesTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Country>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.CountriesTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<Country>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var country in parsedResponse.Items)
                                Countries.GetOrAdd(country.Code, country);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return Countries.Count;
        }

        public async static Task<int> InitializeLeaguesTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<League>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.LeaguesTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<League>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var league in parsedResponse.Items)
                                Leagues.GetOrAdd(league.Id, league);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return Leagues.Count;
        }

        public async static Task<int> InitializeTeamsTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Team>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.TeamsTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<Team>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var team in parsedResponse.Items)
                                Teams.GetOrAdd(team.Id, team);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return Teams.Count;
        }

        public async static Task<int> InitializeBetGroupsTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<BetGroup>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.BetGroupsTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<BetGroup>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var betGroup in parsedResponse.Items)
                                BetGroups.GetOrAdd(betGroup.Id, betGroup);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return BetGroups.Count;
        }

        public async static Task<int> InitializeBetTypesTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<BetType>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.BetTypesTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<BetType>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var betType in parsedResponse.Items)
                                BetTypes.GetOrAdd(betType.Id, betType);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return BetTypes.Count;
        }

        public async static Task<int> InitializeOddTypesTranslations()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<OddType>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.OddTypesTranslationsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<OddType>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var oddType in parsedResponse.Items)
                                OddTypes.GetOrAdd(oddType.Id, oddType);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return OddTypes.Count;
        }
    }
}
