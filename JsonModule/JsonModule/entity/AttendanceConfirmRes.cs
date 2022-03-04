using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class AttendanceConfirmRes : AttendanceManagerBase
    {
        public AttendanceConfirmRes()
        {
            CmdId = 301;
            CmdName = 301;
        }

        [DataMember(Order = 0)]
        public int Status { get; set; }

        [DataMember(Order = 1)]
        public string Personal { get; set; }

        [DataMember(Order = 2)]
        public string Team { get; set; }

        [DataMember(Order = 3)]
        public int IsWork { get; set; }

        [DataMember(Order = 4)]
        public int Place { get; set; }

        [DataMember(Order = 5)]
        public int OverTime { get; set; }
    }
}
