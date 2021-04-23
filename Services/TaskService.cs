using School.Data;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = School.Entities.Task;

namespace School.Services
{
    class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IRepository _repository;
        public TaskService()
        {
            _repository = _unitOfWork.Repository;
        }
        public IEnumerable<Task> GetTask()
        {
            return _repository.GetTasks();
        }
        public void AddTask(Task task)
        {
            _repository.AddTask(task);
            _unitOfWork.SaveTasks();
        }
        public void RemoveTask(int taskId)
        {
            _repository.RemoveTask(taskId);
            _unitOfWork.SaveTasks();
        }
        public int GetMaxId()
        {
            return _repository.GetMaxIdTask();
        }
        public void UpdateTask(Task task, int taskId)
        {
            _repository.UpdateTask(task, taskId);
            _unitOfWork.SaveTasks();
        }
        public void CompleteTask(int taskId) 
        {
            _repository.CompleteTask(taskId);
            _unitOfWork.SaveTasks();
        }
    }
}
