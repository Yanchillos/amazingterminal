using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.StaticDataManager.Entities
{
    [DataContract()]
    public class ViewType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "ic")]
        public int ColumnsCount { get; set; }

        [DataMember(Name = "pc")]
        public int PointsCount { get; set; }
    }
}
