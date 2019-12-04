using HW3AspNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW3AspNet.Controllers
{
    public class ToDoController : Controller
    {
        private ContextToDo db = new ContextToDo();

        // GET: Todoes
        public ActionResult Index()
        {
            return View(db.ToDos.ToList());
        }

        // GET: Todoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo todo = db.ToDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todoes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            //var todoViewModel = new TodoViewModel();
            //Todo todo = new Todo();

            return View();
        }

        // POST: Todoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelToDo todoViewModel)
        {

            if (ModelState.IsValid)
            {
                var tag = new Tag
                {
                    TagName = todoViewModel.Tag.TagName
                };
                var todo = new ToDo
                {
                    Name = todoViewModel.Name,
                    Description = todoViewModel.Description
                };
                tag.Todos.Add(todo);
                todo.Tags.Add(tag);


                db.ToDos.Add(todo);
                db.Tags.Add(tag);

                db.Tags.Add(tag);
                db.ToDos.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoViewModel);
        }

        // GET: Todoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo todo = db.ToDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ToDo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo todo = db.ToDos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo todo = db.ToDos.Find(id);
            db.ToDos.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}