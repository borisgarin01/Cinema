using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.Tickets
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}