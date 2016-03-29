using AmazingTerminal.DataManagers.LineDataManager.Entities;
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

namespace AmazingTerminal.DataManagers.LineDataManager
{
    public static class LineManager
    {
        public static ConcurrentDictionary<int, Sport> Sports { get; private set; }
        public static ConcurrentDictionary<int, League> Leagues { get; private set; }

        static LineManager()
        {
            Sports = new ConcurrentDictionary<int, Sport>();
            Leagues = new ConcurrentDictionary<int, League>();
        }

        public async static Task<int> InitializeSports()
        {
            DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Sport>));
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(AppConfig.GetSportsEndpoint);
                using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                {
                    var parsedResponse = (Response<Sport>)desirializer.ReadObject(memoryStream);
                    if (string.IsNullOrEmpty(parsedResponse.Error))
                        foreach (var sport in parsedResponse.Items)
                            Sports.GetOrAdd(sport.Id, sport);
                }
            }
            return Sports.Count;
        }

        public async static Task<int> InitializeLeagues()
        {
            DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<League>));
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(AppConfig.GetLeaguesEndpoint);
                using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                {
                    var parsedResponse = (Response<League>)desirializer.ReadObject(memoryStream);
                    if (string.IsNullOrEmpty(parsedResponse.Error))
                        foreach (var league in parsedResponse.Items)
                            Leagues.GetOrAdd(league.Id, league);
                }
            }
            return Leagues.Count;
        }
    }
}
