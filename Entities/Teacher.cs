using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Teacher : IEntities
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Post { get; set; }
        public string Rank { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Years { get; set; }
        public int Experience { get; set; }
        public int YearOfCertification { get; set; }
        public int YearOfCourses { get; set; }
        public string PhoneNumb { get; set; }
        public string Email { get; set; }
        public double Load { get; set; }
        public DateTime VacationFrom { get; set; }
        public DateTime VacationTo { get; set; }
        public DateTime SickFrom { get; set; }
        public DateTime SickTo { get; set; }
    }
}
