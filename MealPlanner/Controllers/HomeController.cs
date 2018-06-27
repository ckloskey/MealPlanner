using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealPlanner.Models;

namespace MealPlanner.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var recipies = _context.Recipe.ToList();
            return View(recipies);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipeItem = _context.Recipe.Find(id);
            _context.Recipe.Remove(recipeItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewRecipe()
        {
            return View();
        }
    }
}