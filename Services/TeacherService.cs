using School.Data;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IRepository _repository;
        public TeacherService()
        {
            _repository = _unitOfWork.Repository;
        }
        public IEnumerable<Teacher> GetTeacher()
        {
            return _repository.GetTeachers();
        }
        public int GetMaxId() 
        {
            return _repository.GetMaxIdTeacher();
        }
        public void AddTeacher(Teacher teacher)
        {
            _repository.AddTeacher(teacher);
            _unitOfWork.SaveTeachers();
        }
        public void RemoveTeacher(int teacherId)
        {
            _repository.RemoveTeacher(teacherId);
            _unitOfWork.SaveTeachers();
        }
        public void UpdateTeacher(Teacher teacher, int teacherId)
        {
            _repository.UpdateTeacher(teacher,teacherId);
            _unitOfWork.SaveTeachers();
        }
    }
}
