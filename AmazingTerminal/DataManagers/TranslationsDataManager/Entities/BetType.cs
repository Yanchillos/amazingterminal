using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.TranslationsDataManager.Entities
{
    [DataContract]
    public class BetType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "t")]
        public string Name { get; set; }
    }
}
