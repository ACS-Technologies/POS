using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Main
    {
        public Store store { get; set; }
        public List<Item> Item { get; set; }
        public List<Group> Group { get; set; }
        public List<Category> Category { get; set; }
    }
}