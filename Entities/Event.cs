using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Event : IEntities
    {
        public int ID { get; set; }
        public string Importance { get; set; }
        public DateTime Term { get; set; }
        public string Place { get; set; }
        public string Information { get; set; }
    }
}
