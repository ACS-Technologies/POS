using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace POS.Models
{
    [DataContract]
    [Serializable]
    public class Response
    {
        [DataMember]
        public int ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public bool IsScusses { get; set; }

        [DataMember]
        public object ResponseDetails { get; set; }
    }
}