using MaterialSkin;
using MaterialSkin.Controls;
using School.Services;
using System;
using Serilog;
using System.Windows.Forms;
using Cyriller;
using System.Collections.Generic;

namespace School
{
    public partial class TeachersForm : MaterialForm
    {
        ITeacherService _teacherService = new TeacherService();
        private ListViewColumnSorter lvwColumnSorter;
        private ToDoc doc = new ToDoc();
        public TeachersForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.DeepPurple200, TextShade.WHITE);
            lvwColumnSorter = new ListViewColumnSorter();
            this.teachersListView.ListViewItemSorter = lvwColumnSorter;
            FillTeacherList();
        }
        private void FillTeacherList()
        {
            teachersListView.Items.Clear();
            teachersListView.GridLines = true;
            var result = new CyrNumber();
            var Vacation = "";
            var Sick = "";
            var teachers = _teacherService.GetTeacher();
            DateTime date = new DateTime(2000, 01, 1, 0, 0, 0);
            foreach (var teacher in teachers)
            {
                TimeSpan timeSpan = new TimeSpan();

                if (teacher.VacationFrom != date || teacher.VacationTo != date)
                {
                    timeSpan = teacher.VacationTo - teacher.VacationFrom;
                    Vacation = "с " + teacher.VacationFrom.ToString("dd.MM.yyyy") + " по " + teacher.VacationTo.ToString("dd.MM.yyyy") + " " + timeSpan.Days + " д.";
                }
                if (teacher.SickFrom != date || teacher.SickTo != date)
                {
                    timeSpan = teacher.SickTo - teacher.SickFrom;
                    Sick = "с " + teacher.SickFrom.ToString("dd.MM.yyyy") + " по " + teacher.SickTo.ToString("dd.MM.yyyy") + " " + timeSpan.Days + " д.";
                }
                string hour = "";
                string year = "";
                hour = result.Case(Int64.Parse(((int)teacher.Load).ToString()), "час", "часа", "часов");
                year = result.Case(Int64.Parse((teacher.Experience).ToString()), "год", "года", "лет");
                
                var lvi = new ListViewItem(new[]
                {
                    teacher.ID.ToString(),
                    teacher.FullName,
                    teacher.Post,
                    teacher.Rank,
                    teacher.DateOfBirth.ToString("dd.MM.yyyy"),
                    teacher.Years.ToString(),
                    teacher.Experience.ToString()+ " " +year,
                    teacher.YearOfCertification.ToString(),
                    teacher.YearOfCourses.ToString(),
                    teacher.PhoneNumb+", "+teacher.Email,
                    teacher.Load +" "+hour,
                    Vacation,
                    Sick
                });
                teachersListView.Items.Add(lvi);
            }
        }

        private void teachersListView_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.teachersListView.Sort();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddTeacher add = new AddTeacher
            {
                Text = "Добавить учителя"
            };
            if (add.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newTeacher = add.Teacher;
            _teacherService.AddTeacher(newTeacher);
            FillTeacherList();
            Log.Information($"Пользователь {Status.User} добавил запись {newTeacher.ID}. {newTeacher.FullName}");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeletTeacher();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateTeacher();
        }

        private void deletMenuItem_Click(object sender, EventArgs e)
        {
            DeletTeacher();
        }
        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTeacher();
        }
        private void DeletTeacher()
        {
            if (teachersListView.SelectedIndices.Count == 1)
            {
                var idx = int.Parse(teachersListView.SelectedItems[0].SubItems[0].Text);
                var fullName = teachersListView.SelectedItems[0].SubItems[1].Text;
                if (MessageBox.Show($"Вы действительно хотите удалить эту запись: {idx}.{fullName}", 
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _teacherService.RemoveTeacher(idx);
                    FillTeacherList();
                    Log.Information($"Пользователь {Status.User} удалил запись {idx}.{fullName}");
                }
            }
            else { MessageBox.Show("Выберте одну запись которую хотите удалить.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void UpdateTeacher()
        {
            if (teachersListView.SelectedIndices.Count == 1)
            {
                var idx = int.Parse(teachersListView.SelectedItems[0].SubItems[0].Text);
                var fullName = teachersListView.SelectedItems[0].SubItems[1].Text;
                if (MessageBox.Show($"Вы действительно хотите отредактировать эту запись: {idx}.{fullName}", 
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Status.Update = true;
                    Status.ID = idx;
                    AddTeacher update = new AddTeacher
                    {
                        Text = "Обновить учителя"
                    };
                    if (update.ShowDialog() != DialogResult.OK)
                    {
                        Status.Update = false;
                        return;
                    }
                    var newTeacher = update.Teacher;
                    newTeacher.ID = idx;
                    _teacherService.UpdateTeacher(newTeacher, idx);
                    FillTeacherList();
                    string info = null;
                    if (newTeacher.FullName != fullName) { info = "на " + idx +"."+newTeacher.FullName; }
                    Status.Update = false;
                    Log.Information($"Пользователь {Status.User} отредактировал запись {idx}.{fullName} {info}.");
                }
            }   
            else { MessageBox.Show("Выберите одну запись которую хотите отредактировать.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teachersListView.SelectedIndices.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "export.docx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ListView.SelectedIndexCollection indexes =this.teachersListView.SelectedIndices;
                    string[,] items = new string[teachersListView.SelectedItems.Count+1, 10];
                    items[0, 0] = "№"; items[0, 1] = "ФИО\n(полностью)"; items[0, 2] = "Место работы (полное название)"; items[0, 3] = "Должность"; 
                    items[0, 4] = "Уровень профессионального образования, согласно диплому"; items[0, 5] = "Предметная специализация"; 
                    items[0, 6] = "Квалификация согласно диплому";items[0, 7] = "Педагогический стаж"; 
                    items[0, 8] = "Контактный телефон оператора \"Феникс\""; items[0, 9] = "Адрес электронной почты";
                    int rows = 1;
                    foreach (int index in indexes)
                    {
                        string[] contact = new string[2];
                        contact = teachersListView.Items[index].SubItems[9].Text.Split(' ');
                        items[rows, 0] = rows.ToString();
                        items[rows, 1] =teachersListView.Items[index].SubItems[1].Text;
                        items[rows, 2] ="МУНИЦИПАЛЬНОЕ ОБШЕОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ \"КЛАССИЧЕСКАЯ ГУМАНИТАРНАЯ ГИМНАЗИЯ ГОРОДА ДОНЕЦКА\"";
                        items[rows, 3] = teachersListView.Items[index].SubItems[2].Text;
                        items[rows, 4] ="Высшее профессиональное, специалист";
                        items[rows, 5] ="---";
                        items[rows, 6] ="---";
                        items[rows, 7] = teachersListView.Items[index].SubItems[6].Text;
                        items[rows, 8] = contact[0].Trim(',');
                        items[rows, 9] = contact[1];
                        rows++;
                    }
                    if (!doc.IsFileInUse(sfd.FileName))
                    {
                        doc.CreateWordprocessingDocument(sfd.FileName, 0, items);
                    }
                    else 
                    {
                        MessageBox.Show("Закройте файл в который вы хотите добавить таблицу!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите записи которые хотите добавить в таблицу.",
                "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            foreach (ListViewItem itm in teachersListView.Items)
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
            teachersListView.Items.Clear();
            for (int i = 0; i < mass.Count; i++) 
            {
                if (teachersListView.Items.Contains(mass[i])) 
                {
                    continue;
                }
                teachersListView.Items.Add(mass[i]);
            }
        }

        private void cancelRadioButton_Click(object sender, EventArgs e)
        {
            findTextBox.Text = null;
            FillTeacherList();
        }
    }
}
