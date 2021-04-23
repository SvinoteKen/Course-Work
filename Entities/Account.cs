using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    class Account: IEntities
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
