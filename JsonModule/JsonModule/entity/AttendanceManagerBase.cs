using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class AttendanceManagerBase
    {
        [DataMember(Order = 0)]
        protected int CmdId { get; set; }

        [DataMember(Order = 1)]
        protected int CmdName { get; set; }
    }
}
