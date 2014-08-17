using AutoMapper;
using Microsoft.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskTracker.Web.Data;
using TaskTracker.Web.Infrastructure;
using TaskTracker.Web.Infrastructure.Alerts;
using TaskTracker.Web.Models;
using TaskTracker.Web.ViewModels;

using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace TaskTracker.Web.Controllers
{
    [Authorize]
    public class TasksController : TaskTrackerController
    {
        private readonly ICurrentUser _currentUser;
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        // GET: Tasks
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<RTask>, IEnumerable<TaskViewModel>>(_context.Tasks.OrderBy(x => x.Due).ToList()));
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RTask task = _context.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<RTask,TaskViewModel>(task));
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Due")] Task task)
        public ActionResult Create(CreateTaskViewModel createTaskViewModel )
        {
            if (ModelState.IsValid)
            {
                var task = Mapper.Map<CreateTaskViewModel, RTask>(createTaskViewModel);
                task.Created = DateTime.Now;
                task.Modified = task.Created;
                task.Regarding = _currentUser.User;

                _context.Tasks.Add(task);
                _context.SaveChanges();
                
                return RedirectToAction<TasksController>(c => c.Index()).WithSuccess("Task created");
            }

            return View(createTaskViewModel);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RTask task = _context.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            //return View(task);
            var editTaskViewModel = Mapper.Map<RTask, EditTaskViewModel>(task);
            return View(editTaskViewModel);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Created,Due")] Task task)
        public ActionResult Edit(EditTaskViewModel editTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                var task = _context.Tasks.Find(editTaskViewModel.Id);
                if (task == null)
                    return HttpNotFound();

                task = Mapper.Map<EditTaskViewModel, RTask>(editTaskViewModel,task);

                task.Modified = DateTime.Now;

                _context.Entry(task).State = EntityState.Modified;
                _context.SaveChanges();
                //return RedirectToAction("Index").WithSuccess("Updated");
                return RedirectToAction<TasksController>(c => c.Index()).WithSuccess("Task updated");
            }
            //return View(task);
            return View(editTaskViewModel);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RTask task = _context.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RTask task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            //return RedirectToAction("Index");
            //return this.RedirectToAction(c => c.Index());
            return RedirectToAction<TasksController>(c => c.Index()).WithSuccess("Task deleted.");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
