using System;
using System.Runtime.Serialization;

namespace JsonModule.entity
{
    [Serializable()]
    [DataContract(Namespace = "JsonModule.entity")]
    public class SunTime
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public int OnTime { get; set; }
        [DataMember]
        public int OverTime { get; set; }
    }
}
