using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.OfflineDataManager.Entities
{
    [DataContract]
    public class Event
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "c")]
        public string Code { get; set; }

        [DataMember(Name = "h")]
        public int? HomeId { get; set; }

        [DataMember(Name = "g")]
        public int? GuestId { get; set; }

        [DataMember(Name = "l")]
        public int LeagueId { get; set; }
    }
}
