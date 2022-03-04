using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class ActualOutputRes : AttendanceManagerBase
    {
        public ActualOutputRes()
        {
            CmdId = 401;
            CmdName = 401;
        }

        [DataMember(Order = 0)]
        public int Status { get; set; }

        [DataMember(Order = 1)]
        public List<SunTime> TimeList { get; set; } = new List<SunTime>();
    }
}
