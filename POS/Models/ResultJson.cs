using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class ResultJson
    {
        public ResultJson()
        {
            Errors = new List<string>();
        }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }
        public List<object> DataList { get; set; }
        public string Url { get; set; }

    }
}