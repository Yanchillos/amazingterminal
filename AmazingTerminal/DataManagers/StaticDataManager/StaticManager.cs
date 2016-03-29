using AmazingTerminal.DataManagers.StaticDataManager.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.StaticDataManager
{
    public static class StaticManager
    {
        public static ConcurrentDictionary<int, BetType> BetTypes { get; private set; }
        public static ConcurrentDictionary<int, OddType> OddTypes { get; private set; }
        public static ConcurrentDictionary<int, ViewType> ViewTypes { get; private set; }
        public static ConcurrentDictionary<int, BetGroup> BetGroups { get; private set; }

        static StaticManager()
        {
            BetTypes = new ConcurrentDictionary<int, BetType>();
            OddTypes = new ConcurrentDictionary<int, OddType>();
            ViewTypes = new ConcurrentDictionary<int, ViewType>();
            BetGroups = new ConcurrentDictionary<int, BetGroup>();
        }

        public async static Task<int> InitializeBetTypes()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<BetType>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.BetTypesEndpoint);
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

        public async static Task<int> InitializeOddTypes()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<OddType>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.OddTypesEndpoint);
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

        public async static Task<int> InitializeViewTypes()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<ViewType>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.ViewTypesEndpoint);
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                    {
                        var parsedResponse = (Response<ViewType>)desirializer.ReadObject(memoryStream);
                        if (string.IsNullOrEmpty(parsedResponse.Error))
                            foreach (var viewType in parsedResponse.Items)
                                ViewTypes.GetOrAdd(viewType.Id, viewType);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorManager.WriteErrorToLogs(exception.Message);
            }
            return ViewTypes.Count;
        }

        public async static Task<int> InitializeBetGroups()
        {
            try
            {
                DataContractJsonSerializer desirializer = new DataContractJsonSerializer(typeof(Response<BetGroup>));
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AppConfig.BetGroupsEndpoint);
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
    }
}
