using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.StaticDataManager.Entities
{
    [DataContract]
    public class BetGroup
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "o")]
        public int Ordering { get; set; }
    }
}
