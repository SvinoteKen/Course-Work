using School.Services;

namespace School.Data
{
    interface IUnitOfWork
    {
        IRepository Repository { get; }
        void SaveEvents();
        void SavePupils();
        void SaveTasks();
        void SaveTeachers();
    }
}