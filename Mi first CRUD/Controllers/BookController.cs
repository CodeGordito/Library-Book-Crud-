using Mi_first_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mi_first_CRUD.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (DBModels context = new DBModels())
            {
                return View(context.Book.ToList());
            }
              
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels context = new DBModels())
            {
                return View(context.Book.Where(H => H.Id == id).FirstOrDefault());  
            }
            
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                using (DBModels context = new DBModels())
                {
                 context.Book.Add(book);
                 context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5    ********
        public ActionResult Edit(int id)
        {
            using (DBModels context = new DBModels())
            {
                return View(context.Book.Where(H => H.Id == id).FirstOrDefault());
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                using (DBModels context = new DBModels())
                { 
                    context.Entry(book).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels context = new DBModels())
            {
                return View(context.Book.Where(H => H.Id == id).FirstOrDefault());
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBModels context = new DBModels())
                {
                    Book book = context.Book.Where(h => h.Id == id).FirstOrDefault();
                    context.Book.Remove(book);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
