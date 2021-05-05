using MaterialSkin.Controls;
using School.Entities;
using School.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class AddPupil : MaterialForm
    {
        IPupilService _pupilService = new PupilService();
        public Pupil Pupil { get; set; }
        Test test = new Test();
        public AddPupil()
        {
            InitializeComponent();
            if (Status.Update == true)
            {
                Pupil = _pupilService.GetPupil().FirstOrDefault(x => x.ID == Status.ID);
                string disposal = "";
                DateTime Disposal = new DateTime(2000, 01, 1, 0, 0, 0);
                if (Pupil.DateOfDisposal != Disposal)
                {
                    disposal = Pupil.DateOfDisposal.ToString("dd.MM.yyyy");
                }
                fullNameText.Text = Pupil.FullName;
                dateOfBirthText.Text = Pupil.DateOfBirth.ToString("dd.MM.yyyy");
                yearsText.Text = Pupil.Years.ToString();
                gradeText.Text = Pupil.Grade.ToString();
                addressText.Text = Pupil.District;
                socialComboBox.SelectedItem = Pupil.Social;
                phoneNumbText.Text = Pupil.PhoneNumb;
                dateOfReceiptText.Text = Pupil.DateOfReceipt.ToString("dd.MM.yyyy");
                dateOfDisposalText.Text = disposal;
                parentText.Text = Pupil.Parent;
                phonNumbParentText.Text = Pupil.PhoneNumbParent;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DateTime currDate = DateTime.Now;
            TimeSpan Birthday = currDate - DateTime.Parse(dateOfBirthText.Text);
            DateTime Disposal = new DateTime(2000, 01, 1, 0, 0, 0);
            if (!test.TestFullName(fullNameText.Text) || !test.TestPhonNumb(phoneNumbText.Text) || !test.TestDateOfBirth(dateOfBirthText.Text)
                || !test.TestDateOfReceiptAndDisposal(dateOfReceiptText.Text, dateOfDisposalText.Text))
            {
                return;
            }
            if (dateOfDisposalText.Text != "") 
            {
                Disposal = DateTime.Parse(dateOfDisposalText.Text);
            }
            bool succeess = Int32.TryParse(gradeText.Text,out _);
            if (!succeess)
            {
                MessageBox.Show("Поле \"Класс\" должно содержать только числовые значения",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(gradeText.Text) > 12 || int.Parse(gradeText.Text) < 0) 
            {
                MessageBox.Show("Поле \"Класс\" должно иметь значение от 1 до 11",
                        "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var id = _pupilService.GetMaxId();
            Pupil = new Pupil
            {
                ID = id + 1,
                FullName = fullNameText.Text,
                DateOfBirth = DateTime.Parse(dateOfBirthText.Text),
                Years = int.Parse(yearsText.Text),
                Grade = int.Parse(gradeText.Text),
                District = addressText.Text,
                Social = socialComboBox.Text,
                PhoneNumb = phoneNumbText.Text,
                DateOfReceipt = DateTime.Parse(dateOfReceiptText.Text),
                DateOfDisposal = Disposal,
                Parent = parentText.Text,
                PhoneNumbParent = phonNumbParentText.Text
            };

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
