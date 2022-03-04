using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class AttendanceSendReq : AttendanceManagerBase
    {
        public AttendanceSendReq()
        {
            CmdId = 200;
            CmdName = 200;
        }

        [DataMember(Order = 0)]
        public string Date { get; set; }

        [DataMember(Order = 1)]
        public int Type { get; set; }

        [DataMember(Order = 2)]
        public int Place { get; set; }

        [DataMember(Order = 3)]
        public int Rest { get; set; }

        [DataMember(Order = 4)]
        public string Time { get; set; }

        [DataMember(Order = 5)]
        public int NoWork { get; set; }
    }
}
