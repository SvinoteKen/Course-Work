using School.Entities;
using System.Collections.Generic;

namespace School.Services
{
    interface ITeacherService
    {
        int GetMaxId();
        void AddTeacher(Teacher teacher);
        IEnumerable<Teacher> GetTeacher();
        void RemoveTeacher(int teacherId);
        void UpdateTeacher(Teacher teacher, int teacherId);
    }
}