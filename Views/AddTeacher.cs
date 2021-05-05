using MaterialSkin.Controls;
using School.Entities;
using School.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace School
{
    public partial class AddTeacher : MaterialForm
    {
        ITeacherService _teacherService = new TeacherService();
        public Teacher Teacher { get; set; }
        Test test = new Test(); 
        public AddTeacher()
        {
            InitializeComponent();
            if (Status.Update==true)
            {
                Teacher = _teacherService.GetTeacher().FirstOrDefault(x => x.ID == Status.ID);
                string VacationFrom = "";
                string VacationTo = "";
                string SickFrom = "";
                string SickTo = "";

                DateTime Empty = new DateTime(2000, 01, 1, 0, 0, 0);
                if (Teacher.VacationFrom != Empty)
                {
                    VacationFrom = Teacher.VacationFrom.ToString("dd.MM.yyyy");
                }
                if (Teacher.VacationTo != Empty)
                {
                    VacationTo = Teacher.VacationTo.ToString("dd.MM.yyyy");
                }
                if (Teacher.SickFrom != Empty)
                {
                    SickFrom = Teacher.SickFrom.ToString("dd.MM.yyyy");
                }
                if (Teacher.SickTo != Empty)
                {
                    SickTo = Teacher.SickTo.ToString("dd.MM.yyyy");
                }
                fullNameText.Text = Teacher.FullName;
                postComboBox.SelectedItem = Teacher.Post;
                dateOfBirthText.Text = Teacher.DateOfBirth.ToString("dd.MM.yyyy");
                yearsText.Text = Teacher.Years.ToString();
                experienceText.Text = Teacher.Experience.ToString();
                yearOfCertificationText.Text = Teacher.YearOfCertification.ToString();
                yearOfCoursesText.Text = Teacher.YearOfCourses.ToString();
                phoneNumbText.Text = Teacher.PhoneNumb;
                emailText.Text = Teacher.Email;
                loadText.Text = Teacher.Load.ToString();
                vacationFromText.Text = VacationFrom;
                vacationToText.Text = VacationTo;
                sickFromText.Text = SickFrom;
                sickToText.Text = SickTo;
                rankComboBox.SelectedText = Teacher.Rank;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool succeess1 = true;
            bool succeess2 = true;
            bool succeess3 = true;
            bool succeess4 = true;
            DateTime currDate = DateTime.Now;
            TimeSpan Birthday = currDate - DateTime.Parse(dateOfBirthText.Text);
            DateTime Empty = new DateTime(2000, 01, 1, 0, 0, 0);
            if (!test.TestFullName(fullNameText.Text)|| !test.TestPhonNumb(phoneNumbText.Text)|| !test.TestDateOfBirth(dateOfBirthText.Text)
                || !test.TestyearOfCertificationAndCourses(yearOfCertificationText.Text, yearOfCoursesText.Text)|| !test.TestEmail(emailText.Text)) 
            {
                return;
            }
            if (!test.TestYear(dateOfBirthText.Text, yearsText.Text)) 
            {
                if (MessageBox.Show($"Дата рождения не совпадает с возрастом. Заменить возраст на правильный: {(int)(int.Parse(Birthday.Days.ToString()) / 365.25)} ?",
                    "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
                {
                    yearsText.Text = ((int)(int.Parse(Birthday.Days.ToString()) / 365.25)).ToString();
                }
            }
            if (sickFromText.Text == "" || sickToText.Text == "")
            {
                sickFromText.Text = Empty.ToString("dd.MM.yyyy");
                sickToText.Text = Empty.ToString("dd.MM.yyyy");
            }
            else 
            {
                succeess1 = DateTime.TryParse(sickFromText.Text, out _);
                succeess2 = DateTime.TryParse(sickToText.Text, out _);
            }
            if (vacationFromText.Text == "" || vacationToText.Text == "")
            {
                vacationFromText.Text = Empty.ToString("dd.MM.yyyy");
                vacationToText.Text = Empty.ToString("dd.MM.yyyy");
            }
            else
            {
                succeess3 = DateTime.TryParse(vacationFromText.Text, out _);
                succeess4 = DateTime.TryParse(vacationToText.Text, out _);
            }
            if (!succeess1 || !succeess2 || !succeess3 || !succeess4 )
            {
                MessageBox.Show("Поля \"Отпуск\" и \"Больничный\" должно иметь такой вид: \"dd.mm.yyyy\"",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTime.Parse(vacationFromText.Text) > DateTime.Parse(vacationToText.Text)|| 
                DateTime.Parse(sickFromText.Text) > DateTime.Parse(sickToText.Text)) 
            {
                MessageBox.Show("Поле \"C\" не может быть больше поля \"ПО\"",
                        "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(loadText.Text, out _)) 
            {
                MessageBox.Show("Поле \"Нагрузка\" имеет неверный формат",
                        "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(experienceText.Text,out _)) 
            {
                MessageBox.Show("Поле \"Пед. стаж\" имеет неверный формат",
                            "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = _teacherService.GetMaxId();
            Teacher = new Teacher
            {
                ID = id + 1,
                FullName = fullNameText.Text,
                Post = postComboBox.Text,
                DateOfBirth = DateTime.Parse(dateOfBirthText.Text),
                Years = int.Parse(yearsText.Text),
                Experience = int.Parse(experienceText.Text),
                YearOfCertification = int.Parse(yearOfCertificationText.Text),
                YearOfCourses = int.Parse(yearOfCoursesText.Text),
                PhoneNumb = phoneNumbText.Text,
                Email = emailText.Text,
                Load = double.Parse(loadText.Text),
                VacationFrom = DateTime.Parse(vacationFromText.Text),
                VacationTo = DateTime.Parse(vacationToText.Text),
                SickFrom = DateTime.Parse(sickFromText.Text),
                SickTo = DateTime.Parse(sickToText.Text),
                Rank = rankComboBox.Text
            };

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
