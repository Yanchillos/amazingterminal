using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.StaticDataManager.Entities
{
    [DataContract]
    public class BetType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "n")]
        public string Name { get; set; }

        [DataMember(Name = "bgid")]
        public int BetGroupId { get; set; }

        [DataMember(Name = "cc")]
        public int ColumnsCount { get; set; }

        [DataMember(Name = "bv")]
        public int ViewTypeId { get; set; }

        [DataMember(Name = "r")]
        public int Ordering { get; set; }
    }
}
