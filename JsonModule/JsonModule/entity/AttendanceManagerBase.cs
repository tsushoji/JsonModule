using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class AttendanceManagerBase
    {
        [DataMember]
        protected int CmdId { get; set; }
        [DataMember]
        protected int CmdName { get; set; }
    }
}
