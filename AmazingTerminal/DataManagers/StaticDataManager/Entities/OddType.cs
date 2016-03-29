using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.StaticDataManager.Entities
{
    [DataContract]
    public class OddType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "btid")]
        public int BetTypeId { get; set; }

        [DataMember(Name = "t")]
        public string Name { get; set; }

        [DataMember(Name = "o")]
        public int Ordering { get; set; }

        [DataMember(Name = "sc")]
        public int ColumnIndex { get; set; }
    }
}
