using MaterialSkin;
using MaterialSkin.Controls;
using Serilog;
using System;
using System.Windows.Forms;

namespace School
{
    public partial class DataBaseForm : MaterialForm
    {
        public DataBaseForm()
        {
            InitializeComponent();
            if (!Status.Value) { teacherButton.Enabled = false; pupilsButton.Enabled = false; }
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.DeepPurple200, TextShade.WHITE);
        }
        private void teacherButton_Click(object sender, EventArgs e)
        {
            Log.Information($"Пользователь {Status.User} начал просмотр информации на форме \"Учителя\".");
            TeachersForm f3 = new TeachersForm();
            Hide();
            f3.ShowDialog();
            Show();
        }

        private void pupilsButton_Click(object sender, EventArgs e)
        {
            Log.Information($"Пользователь {Status.User} начал просмотр информации на форме \"Учащиеся\".");
            PupilsForm f4 = new PupilsForm();
            Hide();
            f4.ShowDialog();
            Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Log.Information($"Пользователь {Status.User} вышел из сети.");
            Authorization authorization = new Authorization();
            Hide();
            if (authorization.ShowDialog() != DialogResult.OK) { Application.Exit(); }
            Show();
            if (!Status.Value) { teacherButton.Enabled = false; pupilsButton.Enabled = false; }
        }

        private void eventsButton_Click(object sender, EventArgs e)
        {
            Log.Information($"Пользователь {Status.User} начал просмотр информации на форме \"События\".");
            Status.Journal = true;
            EventsForm eventForm = new EventsForm();
            Hide();
            eventForm.ShowDialog();
            Show();
        }

        private void tasksButton_Click(object sender, EventArgs e)
        {
            Log.Information($"Пользователь {Status.User} начал просмотр информации на форме \"Задачи\".");
            Status.Journal = false;
            TasksForm taskForm = new TasksForm();
            Hide();
            taskForm.ShowDialog();
            Show();
        }

        private void DataBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Information($"Пользователь {Status.User} вышел из сети.");
        }
    }
}
