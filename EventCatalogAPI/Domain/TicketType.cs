﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class TicketType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        //free,Paid,Donation
    }
}
