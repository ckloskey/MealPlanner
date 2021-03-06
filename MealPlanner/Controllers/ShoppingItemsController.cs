﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealPlanner.Models;

namespace MealPlanner.Controllers
{
    public class ShoppingItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingItems
        public ActionResult Index()
        {
           var list = db.IngredientsForRecipes
                    .Where(c => !db.FoodItem
                        .Select(b => b.Name)
                        .Contains(c.IngredientName)
                             ).ToList();
            foreach(var listItem in list)
            {
                ShoppingItem newItem = new ShoppingItem
                {
                    FoodName = listItem.IngredientName,
                   // Quantity = listItem.Amount
                };
                db.ShoppingItem.Add(newItem);
            }
            return View(db.ShoppingItem.ToList());
        }


        public void Add(int? id)
        {
            ShoppingItem shoppingItem = db.ShoppingItem.Find(id);


        }
        // GET: ShoppingItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItem shoppingItem = db.ShoppingItem.Find(id);
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FoodName,Quantity")] ShoppingItem shoppingItem)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingItem.Add(shoppingItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingItem);
        }

        // GET: ShoppingItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItem shoppingItem = db.ShoppingItem.Find(id);
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FoodName,Quantity")] ShoppingItem shoppingItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItem shoppingItem = db.ShoppingItem.Find(id);
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingItem shoppingItem = db.ShoppingItem.Find(id);
            db.ShoppingItem.Remove(shoppingItem);
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
