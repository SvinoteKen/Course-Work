using Newtonsoft.Json;
using School.Data;
using School.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data
{
    class UnitOfWork : IUnitOfWork
    {
        public IRepository Repository { get; } = new Repository();
        public void SaveTeachers()
        {
            var teachers = Repository.GetListTeachers();
            var json = JsonConvert.SerializeObject(teachers, Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            using (var f = File.CreateText("teacher.json"))
            {
                f.Write(json);
            }
        }
        public void SavePupils()
        {
            var pupils = Repository.GetListPupils();
            var json = JsonConvert.SerializeObject(pupils, Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            using (var f = File.CreateText("pupil.json"))
            {
                f.Write(json);
            }
        }
        public void SaveEvents()
        {
            var events = Repository.GetListEvents();
            var json = JsonConvert.SerializeObject(events, Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            using (var f = File.CreateText("event.json"))
            {
                f.Write(json);
            }
        }
        public void SaveTasks()
        {
            var tasks = Repository.GetListTasks();
            var json = JsonConvert.SerializeObject(tasks, Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            using (var f = File.CreateText("task.json"))
            {
                f.Write(json);
            }
        }
    }
}
