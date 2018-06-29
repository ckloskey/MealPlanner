using System;
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
    public class IngredientsForRecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IngredientsForRecipes
        public ActionResult Index()
        {
            var list = db.IngredientsForRecipes
                .Where(c => !db.FoodItem.Select(b => b.Name).Contains(c.IngredientName)).ToList()
                //.GroupBy(x => new { x.IngredientName, x.Amount }).Select(g => new IngredientsForRecipes
                //{
                //    IngredientName = g.Key.IngredientName,
                //    Amount = g.Sum(x => x.Amount)
                //})
                .ToList();
            //var ingredientsForRecipes = db.IngredientsForRecipes.Include(i => i.IdForRecipe);
            return View(list);
        }

        public ActionResult Add(int id)
        {
            IngredientsForRecipes ingredientsForRecipes = db.IngredientsForRecipes.Find(id);
            FoodItem itemToTransfer = new FoodItem
            {
                Name = ingredientsForRecipes.IngredientName,
                DatePurchased = DateTime.Today,
                FoodCategoryId = 13
            };
            db.FoodItem.Add(itemToTransfer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: IngredientsForRecipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientsForRecipes ingredientsForRecipes = db.IngredientsForRecipes.Find(id);
            if (ingredientsForRecipes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientsForRecipes);
        }

        // GET: IngredientsForRecipes/Create
        public ActionResult Create()
        {
            ViewBag.RecipeId = new SelectList(db.Recipe, "Id", "title");
            return View();
        }

        // POST: IngredientsForRecipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArbitraryId,RecipeId,IngredientName,Amount,Unit")] IngredientsForRecipes ingredientsForRecipes)
        {
            if (ModelState.IsValid)
            {
                db.IngredientsForRecipes.Add(ingredientsForRecipes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipeId = new SelectList(db.Recipe, "Id", "title", ingredientsForRecipes.RecipeId);
            return View(ingredientsForRecipes);
        }

        // GET: IngredientsForRecipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientsForRecipes ingredientsForRecipes = db.IngredientsForRecipes.Find(id);
            if (ingredientsForRecipes == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipeId = new SelectList(db.Recipe, "Id", "title", ingredientsForRecipes.RecipeId);
            return View(ingredientsForRecipes);
        }

        // POST: IngredientsForRecipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArbitraryId,RecipeId,IngredientName,Amount,Unit")] IngredientsForRecipes ingredientsForRecipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredientsForRecipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeId = new SelectList(db.Recipe, "Id", "title", ingredientsForRecipes.RecipeId);
            return View(ingredientsForRecipes);
        }

        // GET: IngredientsForRecipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientsForRecipes ingredientsForRecipes = db.IngredientsForRecipes.Find(id);
            if (ingredientsForRecipes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientsForRecipes);
        }

        // POST: IngredientsForRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            IngredientsForRecipes ingredientsForRecipes = db.IngredientsForRecipes.Find(id);
            db.IngredientsForRecipes.Remove(ingredientsForRecipes);
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
