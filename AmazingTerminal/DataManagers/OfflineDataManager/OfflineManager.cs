using AmazingTerminal.DataManagers.OfflineDataManager.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.OfflineDataManager
{
    public static class OfflineManager
    {
        public static ConcurrentDictionary<int, Event> Events { get; private set; }

        static OfflineManager()
        {
            Events = new ConcurrentDictionary<int, Event>();
        }

        public async static Task<int> InitializeEvents()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Event>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.GetEventsEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<Event>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var evnt in parsedResponse.Items)
                                Events.GetOrAdd(evnt.Id, evnt);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return Events.Count;
        }

        public async static Task<List<Odd>> GetOddsByLeagueId(int leagueId)
        {
            List<Odd> odds = new List<Odd>();
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Odd>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.GetOddsByLeagueIdEndpoint(leagueId));
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<Odd>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            odds.AddRange(parsedResponse.Items);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return odds;
        }

        public async static Task<List<Odd>> GetOddsByEventId(int eventId)
        {
            List<Odd> odds = new List<Odd>();
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<Odd>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.GetOddsByEventIdEndpoint(eventId));
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<Odd>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            odds.AddRange(parsedResponse.Items);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return odds;
        }
    }
}