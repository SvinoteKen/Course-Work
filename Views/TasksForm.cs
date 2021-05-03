using MaterialSkin;
using MaterialSkin.Controls;
using School.Services;
using Serilog;
using System;
using Cyriller;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace School
{
    public partial class TasksForm : MaterialForm
    {
        ITaskService taskService = new TaskService();

        ITeacherService _teacherService = new TeacherService();
        private ListViewColumnSorter lvwColumnSorter;
        public TasksForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.DeepPurple200, TextShade.WHITE);
            lvwColumnSorter = new ListViewColumnSorter();
            this.tasksListView.ListViewItemSorter = lvwColumnSorter;
            FillTaskList();
            if (!Status.Value)
            {
                deletMenuItem.Enabled = false;
                updateMenuItem.Enabled = false;
                deleteButton.Enabled = false;
                updateButton.Enabled = false;
            }
        }
        private void FillTaskList()
        {
            DateTime date = DateTime.Now;
            var cyriller = new CyrName();
            tasksListView.Items.Clear();
            tasksListView.GridLines = true;
            var tasks = taskService.GetTask();
            var teachers = _teacherService.GetTeacher();
            string mark;
            
            foreach (var task in tasks)
            {
                if (task.Mark)
                {
                    mark = "Выполнено";
                }
                else 
                {
                    mark = "Не выполнено";
                }
                var lvi = new ListViewItem(new[]
                {
                    task.ID.ToString(),
                    task.Post,
                    task.Importance,
                    task.Term.ToString("до dd.MM.yyyy"),
                    task.Place,
                    task.Information,
                    mark
                });
                tasksListView.Items.Add(lvi);
            }
            foreach (var teacher in teachers)
            {
                string[] fullname = teacher.FullName.Split(' ');
                string name = cyriller.Decline(fullname[0], fullname[1], fullname[2]).Дательный;
                var lvi1 = new ListViewItem(new[]
                {
                    "NN",
                    teacher.Post,
                    "Важно",
                    "до "+(teacher.YearOfCertification+5).ToString(),
                    "-",
                    $"Пройти сертификацию {name} ({teacher.ID})"
                });
                tasksListView.Items.Add(lvi1);
                var lvi2 = new ListViewItem(new[]
                {
                    "NN",
                    teacher.Post,
                    "Важно",
                    "до "+(teacher.YearOfCourses+4).ToString(),
                    "-",
                    $"Пройти курсы повышения квалификации {name} ({teacher.ID})"
                });
                tasksListView.Items.Add(lvi2);
            }
        }

        private void tasksListView_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.tasksListView.Sort();
        }

        private void deletMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTask();
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTask();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddJournal add = new AddJournal
            {
                Text = "Добавить задачу"
            };
            if (add.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newTask = add.Task;
            taskService.AddTask(newTask);
            FillTaskList();
            Log.Information($"Пользователь {Status.User} добавил запись {newTask.ID}.");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateTask();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteTask();
        }
        private void DeleteTask()
        {
            if (tasksListView.SelectedIndices.Count == 1)
            {
                if (tasksListView.SelectedItems[0].SubItems[0].Text != "NN")
                {
                    var idx = int.Parse(tasksListView.SelectedItems[0].SubItems[0].Text);
                    if (MessageBox.Show($"Вы действительно хотите удалить эту запись: {idx}.", "Message", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        taskService.RemoveTask(idx);
                        FillTaskList();
                        Log.Information($"Пользователь {Status.User} удалил запись {idx}.");
                    }
                } 
                else { MessageBox.Show("Данная запись является информативной, ее нельзя удалить либо изменить, но ее можно выполнить.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else { MessageBox.Show("Выберте запись которую хотите удалить.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateTask()
        {
            if (tasksListView.SelectedIndices.Count == 1)
            {
                if (tasksListView.SelectedItems[0].SubItems[0].Text != "NN")
                {
                    var idx = int.Parse(tasksListView.SelectedItems[0].SubItems[0].Text);
                    if (MessageBox.Show($"Вы действительно хотите отредактировать эту запись: {idx}.", 
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Status.Update = true;
                        Status.ID = idx;
                        AddJournal update = new AddJournal
                        {
                            Text = "Обновить событие"
                        };
                        if (update.ShowDialog() != DialogResult.OK)
                        {
                            Status.Update = false;
                            return;
                        }
                        var newTask = update.Task;
                        newTask.ID = idx;
                        taskService.UpdateTask(newTask, idx);
                        FillTaskList();
                        Status.Update = false;
                        Log.Information($"Пользователь {Status.User} отредактировал запись {idx}.");
                    }
                }
                else { MessageBox.Show("Данная запись является информативной, ее нельзя удалить либо изменить, но ее можно выполнить.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else { MessageBox.Show("Выберте запись которую хотите отредактировать.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void completeTaskMenuItem_Click(object sender, EventArgs e)
        {
            if (tasksListView.SelectedIndices.Count == 1) 
            {
                if (tasksListView.SelectedItems[0].SubItems[0].Text == "NN")
                {
                    DateTime dateTime = DateTime.Now;
                    int prevYear;
                    string str = tasksListView.SelectedItems[0].SubItems[5].Text;
                    string idx = str[str.Length - 2].ToString();
                    char type = str[7];
                    var teacher = _teacherService.GetTeacher().FirstOrDefault(x => x.ID == int.Parse(idx));
                    if (type == 'с')
                    {
                        if (teacher.YearOfCertification != dateTime.Year)
                        {
                            prevYear = teacher.YearOfCertification;
                            teacher.YearOfCertification = dateTime.Year;
                            Log.Information($"Пользователь {Status.User} обновил год аттестации с {prevYear} на {dateTime.Year}.");
                        }
                        else { MessageBox.Show("Год аттестации совпадает с нынешней датой","Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else 
                    {
                        if (teacher.YearOfCourses != dateTime.Year)
                        {
                            prevYear = teacher.YearOfCourses;
                            teacher.YearOfCourses = dateTime.Year;
                            Log.Information($"Пользователь {Status.User} обновил год курсов с {prevYear} на {dateTime.Year}.");
                        }
                        else { MessageBox.Show("Год курсов совпадает с нынешней датой", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    _teacherService.UpdateTeacher(teacher,int.Parse(idx));
                    FillTaskList();
                }
                else
                {
                    var idx = int.Parse(tasksListView.SelectedItems[0].SubItems[0].Text);
                    taskService.CompleteTask(idx);
                    FillTaskList();
                }
            }
            else { MessageBox.Show("Выберте запись которую хотите выполнить.",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
