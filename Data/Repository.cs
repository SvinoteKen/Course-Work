using Newtonsoft.Json;
using School.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task = School.Entities.Task;

namespace School.Data
{
    class Repository : IRepository
    {
        private List<Teacher> _teachers = new List<Teacher>();
        private List<Pupil> _pupils = new List<Pupil>();
        private List<Event> _events = new List<Event>();
        private List<Task> _tasks = new List<Task>();
        public IEnumerable<Teacher> GetListTeachers()
        {
            return _teachers.ToArray();
        }
        public int GetMaxIdTeacher()
        {
            int t = GetTeachers().Max(teacher => teacher.ID);
            return t;
        }
        public IEnumerable<Teacher> GetTeachers()
        {

            if (!File.Exists("teacher.json"))
            {
                return null;
            }
            using (var f = File.OpenText("teacher.json"))
            {
                var json = f.ReadToEnd();
                _teachers = JsonConvert.DeserializeObject<Teacher[]>(json, 
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }).ToList();
                return JsonConvert.DeserializeObject<Teacher[]>(json,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            _teachers.Add(teacher);
        }
        public void UpdateTeacher(Teacher teacher, int teacherId)
        {
            _teachers[_teachers.IndexOf(_teachers.FirstOrDefault(d => d.ID == teacherId))] = teacher;
        }
        public void RemoveTeacher(int id)
        {
            var teacher = _teachers.FirstOrDefault(d => d.ID == id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
            }
        }
        public IEnumerable<Pupil> GetListPupils()
        {
            return _pupils.ToArray();
        }
        public int GetMaxIdPupil()
        {
            int t = GetPupils().Max(pupil => pupil.ID); ;
            return t;
        }
        public IEnumerable<Pupil> GetPupils()
        {
            if (!File.Exists("pupil.json"))
            {
                return null;
            }

            using (var f = File.OpenText("pupil.json"))
            {
                var json = f.ReadToEnd();
                _pupils = JsonConvert.DeserializeObject<Pupil[]>(json, 
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }).ToList();
                return JsonConvert.DeserializeObject<Pupil[]>(json,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
        }
        public void AddPupil(Pupil pupil)
        {
            _pupils.Add(pupil);
        }
        public void UpdatePupil(Pupil pupil, int pupilId)
        {
            _pupils[_pupils.IndexOf(_pupils.FirstOrDefault(d => d.ID == pupilId))] = pupil;
        }
        public void RemovePupil(int id)
        {
            var pupil = _pupils.FirstOrDefault(d => d.ID == id);
            if (pupil != null)
            {
                _pupils.Remove(pupil);
            }
        }
        public IEnumerable<Event> GetListEvents()
        {
            return _events.ToArray();
        }
        public int GetMaxIdEvent()
        {
            int t = GetEvents().Max(_event => _event.ID);
            return t;
        }
        public IEnumerable<Event> GetEvents()
        {
            if (!File.Exists("event.json"))
            {
                return null;
            }

            using (var f = File.OpenText("event.json"))
            {
                var json = f.ReadToEnd();
                _events = JsonConvert.DeserializeObject<Event[]>(json, 
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }).ToList();
                return JsonConvert.DeserializeObject<Event[]>(json,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
        }
        public void AddEvent(Event events)
        {
            _events.Add(events);
        }
        public void UpdateEvent(Event _event, int eventId)
        {
            _events[_events.IndexOf(_events.FirstOrDefault(d => d.ID == eventId))] = _event;
        }
        public void RemoveEvent(int id)
        {
            var _event = _events.FirstOrDefault(d => d.ID == id);
            if (_event != null)
            {
                _events.Remove(_event);
            }
        }
        public IEnumerable<Task> GetListTasks()
        {
            return _tasks.ToArray();
        }
        public int GetMaxIdTask()
        {
            int t = GetTasks().Max(task => task.ID);
            return t;
        }
        public IEnumerable<Task> GetTasks()
        {
            if (!File.Exists("task.json"))
            {
                return null;
            }

            using (var f = File.OpenText("task.json"))
            {
                var json = f.ReadToEnd();
                _tasks = JsonConvert.DeserializeObject<Task[]>(json, 
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }).ToList();
                return JsonConvert.DeserializeObject<Task[]>(json,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
        }
        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }
        public void UpdateTask(Task task, int taskId)
        {
            _tasks[_tasks.IndexOf(_tasks.FirstOrDefault(d => d.ID == taskId))] = task;
        }
        public void RemoveTask(int id)
        {
            var task = _tasks.FirstOrDefault(d => d.ID == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
        public void CompleteTask(int id) 
        {
            var task = _tasks.FirstOrDefault(d => d.ID == id);
            if (task != null)
            {
                task.Mark = true;
            }
        }

    }

}
