using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerTest.Models;
namespace TaskManagerTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TasksDataManager tasksDataManager = new TasksDataManager();
            ViewBag.Tasks = tasksDataManager.GetTasks();
            return View(ViewBag.Tasks);
        }
        //edit
        //----------------
        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TasksDataManager tasksDataManager = new TasksDataManager();

            return View(tasksDataManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Tasks task)
        {
            if(ModelState.IsValid)
            {
                TasksDataManager tasksDataManager = new TasksDataManager();
                tasksDataManager.Edit(task);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //edit-end

        //add
        //--------------
        //add
        [HttpGet]
        public ActionResult Add()
        {
            TasksDataManager tasksDataManager = new TasksDataManager();

            return View();
        }

        [HttpPost]
        public ActionResult Add(Tasks task)
        {
            if(ModelState.IsValid)
            {
                TasksDataManager tasksDataManager = new TasksDataManager();
                tasksDataManager.Add(task);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //add-end

        //delete
        //-------------
        //delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TasksDataManager tasksDataManager = new TasksDataManager();
            return View(tasksDataManager.GetById(id));
        }


        [HttpPost]
        public ActionResult Delete(Tasks task)
        {
                TasksDataManager tasksDataManager = new TasksDataManager();
                tasksDataManager.Delete(task);

                return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
