﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Main
    {

        public Store store { get; set; }
        public List<Item> Item { get; set; }
        public List<Group> Group { get; set; }
        public List<Category> Category { get; set; }
        public List<SuspendedSale> SuspendedSale { get; set; }
        public List<User> User { get; set; }

    }
}
