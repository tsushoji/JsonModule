using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class SunTime
    {
        [DataMember(Order = 0)]
        public string Date { get; set; }

        [DataMember(Order = 1)]
        public int OnTime { get; set; }

        [DataMember(Order = 2)]
        public int OverTime { get; set; }
    }
}
