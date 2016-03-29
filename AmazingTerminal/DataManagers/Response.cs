using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers
{
    [DataContract]
    public class Response<T> : BaseResponse
    {
        [DataMember(Name = "response")]
        public List<T> Items { get; set; }
    }
}
