using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class ActualOutputRes : AttendanceManagerBase
    {
        public ActualOutputRes () 
        {
            CmdId = 401;
            CmdName = 401;
        }

        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public List<SunTime> TimeList { get; set; } = new List<SunTime>();
    }
}
