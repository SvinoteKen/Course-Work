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
                fullNameText.Text = Pupil.FullName;
                dateOfBirthText.Text = Pupil.DateOfBirth.ToString("dd.MM.yyyy");
                yearsText.Text = Pupil.Years.ToString();
                gradeText.Text = Pupil.Grade.ToString();
                addressText.Text = Pupil.District;
                socialComboBox.SelectedItem = Pupil.Social;
                phoneNumbText.Text = Pupil.PhoneNumb;
                dateOfReceiptText.Text = Pupil.DateOfReceipt.ToString("dd.MM.yyyy");
                dateOfDisposalText.Text = Pupil.DateOfDisposal.ToString("dd.MM.yyyy");
                parentText.Text = Pupil.Parent;
                phonNumbParentText.Text = Pupil.PhoneNumbParent;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int x;
            if (!test.TestFullName(fullNameText.Text) || !test.TestPhonNumb(phoneNumbText.Text) || !test.TestDateOfBirth(dateOfBirthText.Text)
                || !test.TestDateOfReceiptAndDisposal(dateOfReceiptText.Text, dateOfDisposalText.Text) || !test.TestYear(dateOfBirthText.Text, yearsText.Text))
            {
                return;
            }
            bool succeess = Int32.TryParse(gradeText.Text,out x);
            if (!succeess)
            {
                MessageBox.Show("Поле \"Класс\" должно содержать только числовые значения",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(gradeText.Text) > 12 || int.Parse(gradeText.Text) < 0) 
            {
                MessageBox.Show("Поле \"Класс\" должно иметь значение от 1 до 12",
                        "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                DateOfDisposal = DateTime.Parse(dateOfDisposalText.Text),
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
