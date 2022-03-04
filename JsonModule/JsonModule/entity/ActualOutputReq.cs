using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class ActualOutputReq : AttendanceManagerBase
    {
        public ActualOutputReq()
        {
            CmdId = 400;
            CmdName = 400;
        }

        [DataMember(Order = 0)]
        public string From { get; set; }

        [DataMember(Order = 1)]
        public string To { get; set; }

        [DataMember(Order = 2)]
        public string Addres { get; set; }
    }
}
