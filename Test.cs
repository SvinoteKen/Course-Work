using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    class Test
    {
        public bool TestFullName(string text)
        {
            Regex regex = new Regex(@"^[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+$");
            if (regex.Matches(text).Count == 0)
            {
                MessageBox.Show("Поле \"ФИО\" должно иметь такой вид: \"Фамилия Имя Отчество\"", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public bool TestPhonNumb(string text)
        {
            Regex regex = new Regex(@"^\+071-\d{3}-\d{2}-\d{2}$");
            if (regex.Matches(text).Count == 0)
            {
                MessageBox.Show("Поле \"Контактные данные\" должно иметь такой вид: \"+071-999-99-99\"", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public bool TestEmail(string text)
        {
            Regex regex = new Regex(@"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)");
            if (regex.Matches(text).Count == 0)
            {
                MessageBox.Show("Поле \"Почта\" должно иметь такой вид: \"gmail@gmail.com\"", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public bool TestDateOfBirth(string text)
        {
            DateTime dateTime;
            bool succeess = DateTime.TryParse(text, out dateTime);
            if (!succeess)
            {
                MessageBox.Show("Поле \"Дата рождения\" должно иметь такой вид: \"dd.mm.yyyy\"",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public bool TestyearOfCertificationAndCourses(string yearCertification,string yearCourses)
        {
            int x;
            int currYear = DateTime.Now.Year;
            bool Year1 = Int32.TryParse(yearCertification, out x);
            bool Year2 = Int32.TryParse(yearCourses, out x);
            if (!Year1 || !Year2)
            {
                MessageBox.Show("Поля \"Год аттестации\" и \"Год курсов\" должно иметь такой вид: \"yyyy\"",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (currYear - int.Parse(yearCourses) < 0 || currYear - int.Parse(yearCertification) < 0)
            {
                MessageBox.Show("Дата курсов и аттестации не может превышать нынешнюю дату",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public bool TestDateOfReceiptAndDisposal(string dateOfReceipt, string dateOfDisposal)
        {
            DateTime dateTime;
            bool succeess1 = DateTime.TryParse(dateOfReceipt, out dateTime);
            bool succeess2 = DateTime.TryParse(dateOfDisposal, out dateTime);
            if (!succeess1)
            {
                MessageBox.Show("Поля \"Дата приема\" и \"Дата выбытия\" должно иметь такой вид: \"dd.mm.yyyy\"",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
       public bool TestYear(string dateBirth,string years)
        {
            DateTime currDate = DateTime.Now;
            TimeSpan Birthday = currDate - DateTime.Parse(dateBirth);
            if ((int)(int.Parse(Birthday.Days.ToString()) / 365) != int.Parse(years))
            {
                MessageBox.Show("Дата рождения не совпадает с возрастом",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
