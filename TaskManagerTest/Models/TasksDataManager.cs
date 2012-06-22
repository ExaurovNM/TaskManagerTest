using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerTest.Models
{
    public class TasksDataManager : IDisposable
    {
        private TasksDBEntities _db;

        public TasksDataManager()
        {
            _db = new TasksDBEntities();
        }

        public IQueryable<Tasks> GetTasks()
        {
            return _db.Tasks;
        }

        public Tasks GetById(int id)
        {
            return _db.Tasks.SingleOrDefault(x => x.id == id);
        }

        public void Edit(Tasks task)
        {
            Tasks oldTask = GetById(task.id);
            oldTask.Title = task.Title;
            oldTask.Subject = task.Subject;
            _db.SaveChanges();
        }

        public void Add (Tasks tasks)
        {
            _db.Tasks.AddObject(tasks);
            _db.SaveChanges();
        }

        public void Delete(Tasks task)
        {
            Tasks oldTask = GetById(task.id);
            _db.Tasks.DeleteObject(oldTask);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}