﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Store
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string logo { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string currency_code { get; set; }
        public string receipt_header { get; set; }
        public string receipt_footer { get; set; }

    }
}