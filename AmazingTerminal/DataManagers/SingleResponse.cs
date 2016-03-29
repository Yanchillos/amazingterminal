using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers
{
    [DataContract]
    public class SingleResponse<T> : BaseResponse
    {
        [DataMember(Name = "response")]
        public T Item { get; set; }
    }
}
