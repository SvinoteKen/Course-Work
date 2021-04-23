using School.Entities;
using System.Collections.Generic;

namespace School.Services
{
    interface ITaskService
    {
        void AddTask(Task task);
        int GetMaxId();
        IEnumerable<Task> GetTask();
        void RemoveTask(int taskId);
        void UpdateTask(Task task, int taskId);
        void CompleteTask(int taskId);
    }
}