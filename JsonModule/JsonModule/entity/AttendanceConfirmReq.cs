using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class AttendanceConfirmReq : AttendanceManagerBase
    {
        public AttendanceConfirmReq()
        {
            CmdId = 300;
            CmdName = 300;
        }

        [DataMember(Order = 0)]
        public int Type { get; set; }

        [DataMember(Order = 1)]
        public string Word { get; set; }
    }
}
