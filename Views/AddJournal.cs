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
using Task = School.Entities.Task;

namespace School
{
    public partial class AddJournal : MaterialForm
    {
        IEventService _eventService = new EventService();
        public Event Event { get; set; }
        ITaskService _taskService = new TaskService();
        public Task Task { get; set; }
        public AddJournal()
        {
            InitializeComponent();
            if (Status.Journal == true) { materialLabel6.Visible = false;postComboBox.Visible = false; }
            if (Status.Update == true&&Status.Journal==true)
            {
                Event = _eventService.GetEvent().FirstOrDefault(x => x.ID == Status.ID);
                importanceComboBox.SelectedItem = Event.Importance;
                termText.Text = Event.Term.ToString("dd.MM.yyyy");
                placeText.Text = Event.Place;
                informationText.Text = Event.Information;
            }
            if (Status.Update == true && Status.Journal == false)
            {
                Task = _taskService.GetTask().FirstOrDefault(x => x.ID == Status.ID);
                importanceComboBox.SelectedItem = Task.Importance;
                termText.Text = Task.Term.ToString("dd.MM.yyyy");
                placeText.Text = Task.Place;
                informationText.Text = Task.Information;
                postComboBox.SelectedItem = Task.Post;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool succeess = DateTime.TryParse(termText.Text, out DateTime dateTime);
            if (!succeess)
            {
                MessageBox.Show("Поле \"Срок\"  должно иметь такой вид: \"dd.mm.yyyy\"",
                    "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Status.Journal == true)
            {
                var id = _eventService.GetMaxId();
                Event = new Event
                {
                    ID = id + 1,
                    Importance = importanceComboBox.Text,
                    Term = DateTime.Parse(termText.Text),
                    Place = placeText.Text,
                    Information = informationText.Text
                };
            }
            else 
            {
                var id = _taskService.GetMaxId();
                Task = new Task
                {
                    ID = id + 1,
                    Post = postComboBox.Text,
                    Importance = importanceComboBox.Text,
                    Term = DateTime.Parse(termText.Text),
                    Place = placeText.Text,
                    Information = informationText.Text,
                    Mark = false
                };
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
