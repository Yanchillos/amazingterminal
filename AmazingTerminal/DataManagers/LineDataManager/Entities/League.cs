using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.LineDataManager.Entities
{
    [DataContract]
    public class League
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "sId")]
        public int SportId { get; set; }

        [DataMember(Name = "c")]
        public string CountryName { get; set; }

        [DataMember(Name = "cc")]
        public string CountryCode { get; set; }
    }
}
