using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class LoginRes : AttendanceManagerBase
    {
        public LoginRes()
        {
            CmdId = 101;
            CmdName = 101;
        }

        [DataMember(Order = 0)]
        public int Status { get; set; }

        [DataMember(Order = 1)]
        public int Authority { get; set; }
    }
}
