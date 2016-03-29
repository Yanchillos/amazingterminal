using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.OfflineDataManager.Entities
{
    [DataContract]
    public class Odd
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "bt")]
        public int BetTypeId { get; set; }

        [DataMember(Name = "ot")]
        public int OddTypeId { get; set; }

        [DataMember(Name = "eid")]
        public int EventId { get; set; }

        [DataMember(Name = "f")]
        public double Factor { get; set; }

        [DataMember(Name = "p")]
        public double Point { get; set; }

        [DataMember(Name = "s")]
        public int Status { get; set; }

        [DataMember(Name = "ic")]
        public int OddColumnCount { get; set; }

        [DataMember(Name = "sc")]
        public int ColumnIndex { get; set; }

        [DataMember(Name = "vt")]
        public int ViewTypeId { get; set; }

        [DataMember(Name = "o")]
        public int Ordering { get; set; }

        [DataMember(Name = "pc")]
        public int PointsCount { get; set; }
    }
}
