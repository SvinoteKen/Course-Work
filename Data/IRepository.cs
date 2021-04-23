using School.Entities;
using System.Collections.Generic;

namespace School.Data
{
    interface IRepository
    {
        void AddEvent(Event events);
        void AddPupil(Pupil pupil);
        void AddTask(Task task);
        void AddTeacher(Teacher teacher);
        IEnumerable<Event> GetEvents();
        IEnumerable<Event> GetListEvents();
        IEnumerable<Pupil> GetListPupils();
        IEnumerable<Task> GetListTasks();
        IEnumerable<Teacher> GetListTeachers();
        int GetMaxIdEvent();
        int GetMaxIdPupil();
        int GetMaxIdTask();
        int GetMaxIdTeacher();
        IEnumerable<Pupil> GetPupils();
        IEnumerable<Task> GetTasks();
        IEnumerable<Teacher> GetTeachers();
        void RemoveEvent(int id);
        void RemovePupil(int id);
        void RemoveTask(int id);
        void RemoveTeacher(int id);
        void UpdateEvent(Event _event, int eventId);
        void UpdatePupil(Pupil pupil, int pupilId);
        void UpdateTask(Task task, int taskId);
        void UpdateTeacher(Teacher teacher, int teacherId);
        void CompleteTask(int id);
    }
}