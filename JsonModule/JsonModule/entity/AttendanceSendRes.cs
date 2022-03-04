using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class AttendanceSendRes : AttendanceManagerBase
    {
        public AttendanceSendRes()
        {
            CmdId = 201;
            CmdName = 201;
        }

        [DataMember(Order = 0)]
        public int Status { get; set; }
    }
}
