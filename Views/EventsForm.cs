using MaterialSkin;
using MaterialSkin.Controls;
using School.Services;
using Serilog;
using Cyriller;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace School
{
    public partial class EventsForm : MaterialForm
    {
        IEventService _eventService = new EventService();
        ITeacherService _teacherService = new TeacherService();
        IPupilService _pupilService = new PupilService();
        private ListViewColumnSorter lvwColumnSorter;
        public EventsForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.DeepPurple200, TextShade.WHITE);
            lvwColumnSorter = new ListViewColumnSorter();
            this.eventsListView.ListViewItemSorter = lvwColumnSorter;
            FillEventList();
            if (!Status.Value)
            {
                addButton.Enabled = false;
                deletMenuItem.Enabled = false;
                updateMenuItem.Enabled = false;
                deleteButton.Enabled = false;
                updateButton.Enabled = false;
            }
        }
        private void FillEventList()
        {
            DateTime date = DateTime.Now;
            var cyriller = new CyrName();
            eventsListView.Items.Clear();
            eventsListView.GridLines = true;
            var events = _eventService.GetEvent();
            var pupils = _pupilService.GetPupil().Where(x => x.DateOfBirth.Month - date.Month == 1|| x.DateOfBirth.Month - date.Month == 0);
            var teachers = _teacherService.GetTeacher().Where(x => x.DateOfBirth.Month - date.Month == 1|| x.DateOfBirth.Month - date.Month == 0);
            foreach (var _event in events)
            {
                var lvi = new ListViewItem(new[]
                {
                    _event.ID.ToString(),
                    _event.Importance,
                    _event.Term.ToString("до dd.MM.yyyy"),
                    _event.Place,
                    _event.Information
                }) ;
                eventsListView.Items.Add(lvi);
            }
            foreach (var pupil in pupils)
            {
                string[] fullname = pupil.FullName.Split(' ');
                string name = cyriller.Decline(fullname[0],fullname[1],fullname[2]).Родительный;
                var lvi = new ListViewItem(new[]
                {
                    "NN",
                    "Не важно",
                    pupil.DateOfBirth.ToString("dd.MM.")+date.Year.ToString(),
                    "Школа",
                    "День рождение у ученика "+name
                });
                eventsListView.Items.Add(lvi);
            }
            foreach (var teacher in teachers)
            {
                string[] fullname = teacher.FullName.Split(' ');
                string name = cyriller.Decline(fullname[0], fullname[1], fullname[2]).Родительный;
                var lvi = new ListViewItem(new[]
                {
                    "NN",
                    "Не важно",
                    teacher.DateOfBirth.ToString("dd.MM.")+date.Year.ToString(),
                    "Школа",
                    "День рождение у учителя "+name
                });
                eventsListView.Items.Add(lvi);
            }
        }

        private void eventsListView_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.eventsListView.Sort();
        }

        private void deletMenuItem_Click(object sender, EventArgs e)
        {
            DeletEvent();
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            UpdateEvent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddJournal add = new AddJournal
            {
                Text = "Добавить событие"
            };
            if (add.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var newEvent = add.Event;
            _eventService.AddEvent(newEvent);
            FillEventList();
            Log.Information($"Пользователь {Status.User} добавил запись {newEvent.ID}.");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateEvent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeletEvent();
        }
        private void DeletEvent()
        {
            if (eventsListView.SelectedIndices.Count > 0)
            {
                if (eventsListView.SelectedItems[0].SubItems[0].Text != "NN")
                {
                    var idx = int.Parse(eventsListView.SelectedItems[0].SubItems[0].Text);
                    if (MessageBox.Show($"Вы действительно хотите удалить эту запись: {idx}.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _eventService.RemoveEvent(idx);
                        FillEventList();
                        Log.Information($"Пользователь {Status.User} удалил запись {idx}.");
                    }

                }
                else { MessageBox.Show("Данная запись является чисто информативной, ее нельзя удалить либо изменить."); }
            }
            else { MessageBox.Show("Выберте запись которую хотите удалить."); }
        }
        private void UpdateEvent()
        {
            if (eventsListView.SelectedIndices.Count > 0)
            {
                if (eventsListView.SelectedItems[0].SubItems[0].Text != "NN") 
                { 
                    var idx = int.Parse(eventsListView.SelectedItems[0].SubItems[0].Text);
                    if (MessageBox.Show($"Вы действительно хотите отредактировать эту запись: {idx}.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        var newEvent = update.Event;
                        newEvent.ID = idx;
                        _eventService.UpdateEvent(newEvent, idx);
                        FillEventList();
                        Status.Update = false;
                        Log.Information($"Пользователь {Status.User} отредактировал запись {idx}.");
                    }
                }
                else { MessageBox.Show("Данная запись является чисто информативной, ее нельзя удалить либо изменить."); }
            }
            else { MessageBox.Show("Выберте запись которую хотите отредактировать."); }
        }
    }
}
