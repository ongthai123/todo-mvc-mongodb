using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using todo_list.Models;
using todo_list.Services;

namespace todo_list.Controllers
{
    public class TodoController : Controller
    {
        TodoService _todoService;

        public TodoController()
        {
            _todoService = new TodoService();
        }

        // GET: Todo
        public ActionResult Index()
        {
            return View(_todoService.GetTodos());
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var newTodo = new Todo
                {
                    Name = collection["Name"],
                    IsCompleted = false
                };

                _todoService.Create(newTodo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(string id)
        {
            var todo = _todoService.GetTodo(id);
            return View(todo);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                if(id == null)
                {
                    return RedirectToAction("Index");
                }

                var Name = collection["Name"];
                var IsCompleted = collection["IsCompleted"].IndexOf("true") != -1;

                var editingTodo = new Todo
                {
                    Id = id,
                    Name = Name,
                    IsCompleted = IsCompleted
                };

                _todoService.Update(id, editingTodo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(string id)
        {
            var todo = _todoService.GetTodo(id);
            return View(todo);
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                _todoService.Remove(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
