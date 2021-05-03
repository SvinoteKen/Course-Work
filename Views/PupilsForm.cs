using MaterialSkin;
using MaterialSkin.Controls;
using School.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace School
{
    public partial class PupilsForm : MaterialForm
    {
        IPupilService _pupilService = new PupilService();
        private ListViewColumnSorter lvwColumnSorter;

        private ToDoc doc = new ToDoc();
        public PupilsForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.DeepPurple200, TextShade.WHITE);
            lvwColumnSorter = new ListViewColumnSorter();
            this.pupilsListView.ListViewItemSorter = lvwColumnSorter;
            FillPupilList();
        }
        private void FillPupilList()
        {
            pupilsListView.Items.Clear();
            pupilsListView.GridLines = true;
            var pupils = _pupilService.GetPupil();
            string disposal = "";
            DateTime date = new DateTime(2000, 01, 1, 0, 0, 0);
            foreach (var pupil in pupils)
            {
                if (pupil.DateOfDisposal != date)
                {
                    disposal = pupil.DateOfDisposal.ToString("dd.MM.yyyy");
                }
                var lvi = new ListViewItem(new[]
                {
                    pupil.ID.ToString(),
                    pupil.FullName,
                    pupil.DateOfBirth.ToString("dd.MM.yyyy"),
                    pupil.Years.ToString(),
                    pupil.Grade.ToString() + "класс",
                    pupil.District,
                    pupil.Social,
                    pupil.PhoneNumb,
                    pupil.DateOfReceipt.ToString("dd.MM.yyyy"),
                    disposal,
                    pupil.Parent,
                    pupil.PhoneNumbParent
                }) ;
                pupilsListView.Items.Add(lvi);
            }
            
        }

        private void pupilsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.pupilsListView.Sort();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPupil add = new AddPupil
            {
                Text = "Добавить ученика"
            };
            if (add.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newPupil = add.Pupil;
            _pupilService.AddPupil(newPupil);
            FillPupilList();
            Log.Information($"Пользователь {Status.User} добавил запись {newPupil.ID}. {newPupil.FullName}");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdatePupil();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeletPupil();
        }
        private void deletMenuItem_Click(object sender, EventArgs e)
        {
            DeletPupil();
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePupil();
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pupilsListView.SelectedIndices.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "export.docx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DateTime currDate = DateTime.Now;
                    DateTime season=new DateTime();
                    if (currDate.Month == 12 || currDate.Month == 1 || currDate.Month ==2) 
                    { 
                        if(currDate.Month == 12) { season = new DateTime(currDate.Year+1, 2, 1); }
                        else { season = new DateTime(currDate.Year, 2, 1); }
                    }
                    if (currDate.Month >2 &&currDate.Month<6) { season = new DateTime(currDate.Year, 5, 1); }
                    if (currDate.Month > 5 && currDate.Month < 9) { season = new DateTime(currDate.Year, 8, 1); }
                    if (currDate.Month > 8 && currDate.Month < 12) { season = new DateTime(currDate.Year, 11, 1); }
                    ListView.SelectedIndexCollection indexes = this.pupilsListView.SelectedIndices;
                    string[,] items = new string[pupilsListView.SelectedItems.Count + 1, 9];
                    items[0, 0] = "№"; items[0, 1] = "ФИО ребенка"; items[0, 2] = "Дата рождения"; items[0, 3] = $"Возраст(полных лет на {season:dd.MM.yyyy})";
                    items[0, 4] = "Место учебы, класс"; items[0, 5] = "Место проживания";
                    items[0, 6] = "Родители или лица их заменяющие (ФИО, контактный телефон)"; items[0, 7] = "Реквизиты свидетельства о рождении, дата выдачи";
                    items[0, 8] = "Категория";
                    int rows = 1;
                    foreach (int index in indexes)
                    {
                        TimeSpan Birthday = season - DateTime.Parse(pupilsListView.Items[index].SubItems[2].Text);
                        items[rows, 0] = rows.ToString();
                        items[rows, 1] = pupilsListView.Items[index].SubItems[1].Text;
                        items[rows, 2] = pupilsListView.Items[index].SubItems[2].Text;
                        items[rows, 3] = (Birthday.Days/365).ToString();
                        items[rows, 4] = $"МОУ «ДКГГ», {pupilsListView.Items[index].SubItems[4].Text} класс";
                        items[rows, 5] = pupilsListView.Items[index].SubItems[5].Text;
                        items[rows, 6] = pupilsListView.Items[index].SubItems[10].Text+"\n т."+ pupilsListView.Items[index].SubItems[11].Text;
                        items[rows, 7] = "---";
                        items[rows, 8] = pupilsListView.Items[index].SubItems[6].Text;
                        rows++;
                    }
                    if (!doc.IsFileInUse(sfd.FileName))
                    {
                        doc.CreateWordprocessingDocument(sfd.FileName, 1, items);
                    }
                    else
                    {
                        MessageBox.Show("Закройте файл в который вы хотите добавить таблицу!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Выберите записи которые хотите добавить в таблицу.",
                "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeletPupil()
        {
            if (pupilsListView.SelectedIndices.Count == 1)
            {
                var idx = int.Parse(pupilsListView.SelectedItems[0].SubItems[0].Text);
                var fullName = pupilsListView.SelectedItems[0].SubItems[1].Text;
                if (MessageBox.Show($"Вы действительно хотите удалить эту запись: {idx}.{fullName}", 
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _pupilService.RemovePupil(idx);
                    FillPupilList();
                    Log.Information($"Пользователь {Status.User} удалил запись {idx}.{fullName}");
                }
            }
            else { MessageBox.Show("Выберте одну запись которую хотите удалить.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void UpdatePupil()
        {
            if (pupilsListView.SelectedIndices.Count == 1)
            {
                var idx = int.Parse(pupilsListView.SelectedItems[0].SubItems[0].Text);
                var fullName = pupilsListView.SelectedItems[0].SubItems[1].Text;
                if (MessageBox.Show($"Вы действительно хотите отредактировать эту запись: {idx}.{fullName}", 
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Status.Update = true;
                    Status.ID = idx;
                    AddPupil update = new AddPupil
                    {
                        Text = "Обновить ученика"
                    };
                    if (update.ShowDialog() != DialogResult.OK)
                    {
                        Status.Update = false;
                        return;
                    }
                    var newPupil = update.Pupil;
                    newPupil.ID = idx;
                    _pupilService.UpdatePupil(newPupil, idx);
                    FillPupilList();
                    string info = null;
                    if (newPupil.FullName != fullName) { info = "на " + idx + "." + newPupil.FullName; }
                    Status.Update = false;
                    Log.Information($"Пользователь {Status.User} отредактировал запись {idx}.{fullName} {info}.");
                }
            }
            else { MessageBox.Show("Выберте одну запись которую хотите отредактировать.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void findRadioButton_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text == "")
            {
                MessageBox.Show("Поле для пойска пустое",
                "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ListViewItem> mass = new List<ListViewItem>();
            foreach (ListViewItem itm in pupilsListView.Items)
            {
                for (int i = 0; i < itm.SubItems.Count; i++)
                {
                    if (itm.SubItems[i].Text.IndexOf(findTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        mass.Add(itm);
                    }
                }
            }
            if (mass.Count == 0)
            {
                MessageBox.Show("Совпадений не найдено",
                "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            pupilsListView.Items.Clear();
            for (int i = 0; i < mass.Count; i++)
            {
                if (pupilsListView.Items.Contains(mass[i]))
                {
                    continue;
                }
                pupilsListView.Items.Add(mass[i]);
            }
        }

        private void cancelRadioButton_Click(object sender, EventArgs e)
        {
            findTextBox.Text = null;
            FillPupilList();
        }
    }
}
