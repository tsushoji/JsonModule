using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class LoginReq : AttendanceManagerBase
    {
        public LoginReq()
        {
            CmdId = 100;
            CmdName = 100;
        }

        [DataMember(Order = 0)]
        public string Address { get; set; }
    }
}
