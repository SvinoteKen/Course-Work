using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Pupil : IEntities
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Years { get; set; }
        public int Grade { get; set; }
        public string District { get; set; }
        public string Social { get; set; }
        public string PhoneNumb { get; set; }

        public DateTime DateOfReceipt { get; set; }

        public DateTime DateOfDisposal { get; set; }

        public string Parent { get; set; }
        public string PhoneNumbParent { get; set; }
    }
}
