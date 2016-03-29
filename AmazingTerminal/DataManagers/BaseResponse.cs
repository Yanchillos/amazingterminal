using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers
{
    [DataContract]
    public abstract class BaseResponse
    {
        [DataMember(Name = "error")]
        public string Error { get; set; }
    }
}
