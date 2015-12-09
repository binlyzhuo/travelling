using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisProject
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public Person Owner { get; set; }
    }
}
