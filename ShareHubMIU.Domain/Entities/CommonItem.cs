﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Domain.Entities
{
    public class CommonItem : Item
    {
        public string Name { get; set; } // e.g., Sofa, Laptop
        public string Condition { get; set; } // e.g., New, Used
    }

}
