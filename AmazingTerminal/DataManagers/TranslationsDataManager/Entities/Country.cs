using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers.TranslationsDataManager.Entities
{
    [DataContract]
    public class Country
    {
        [DataMember(Name = "t")]
        public string Name { get; set; }

        [DataMember(Name = "rc")]
        public string Code { get; set; }
    }
}
