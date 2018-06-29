using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MealPlanner.Models;

namespace MealPlanner.Controllers
{
    public class GeneralUsersController : Controller
    {
        private ApplicationDbContext db;

        public GeneralUsersController()
        {
            db = new ApplicationDbContext();
        }
        // GET: GeneralUsers
        public ActionResult Index()
        {
            RapidApiConnection api = new RapidApiConnection();
           api.SearchByIngredients();
            return View();
        }

        // GET: GeneralUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralUser generalUser = db.GeneralUser.Find(id);
            if (generalUser == null)
            {
                return HttpNotFound();
            }
            return View(generalUser);
        }

        // GET: GeneralUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] GeneralUser generalUser)
        {
            if (ModelState.IsValid)
            {
                db.GeneralUser.Add(generalUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalUser);
        }

        // GET: GeneralUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralUser generalUser = db.GeneralUser.Find(id);
            if (generalUser == null)
            {
                return HttpNotFound();
            }
            return View(generalUser);
        }

        // POST: GeneralUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] GeneralUser generalUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalUser);
        }

        // GET: GeneralUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralUser generalUser = db.GeneralUser.Find(id);
            if (generalUser == null)
            {
                return HttpNotFound();
            }
            return View(generalUser);
        }

        // POST: GeneralUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralUser generalUser = db.GeneralUser.Find(id);
            db.GeneralUser.Remove(generalUser);
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
