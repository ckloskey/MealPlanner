using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        RapidApiConnection rapidApiConnection;
        public HomeController()
        {
            _context = new ApplicationDbContext();
            rapidApiConnection = new RapidApiConnection();
        }
        public ActionResult Index(bool saved = false)
        {
            if (saved == false)
            {
                var recipies = _context.Recipe.Where(p => p.Saved == false).ToList();
                if (recipies.Count == 0 || recipies == null)
                {
                    rapidApiConnection.GetRandomRecipeMethods();
                    recipies = _context.Recipe.Where(p => p.Saved == false).ToList();
                }
                return View(recipies);
            }
            else
            {
                var recipies = _context.Recipe.Where(p => p.Saved == true).ToList();
                return View(recipies);
            }
        }

        public ActionResult SavedRecipes()
        {
            return RedirectToAction("Index", new { saved = true });
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
            var ingredientsToDelete = _context.IngredientsForRecipes.Where(x => x.RecipeId == recipeItem.Id).ToList();

            foreach(var x in ingredientsToDelete)
            {
                _context.IngredientsForRecipes.Remove(x);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewRecipe(int id)
        {
            Recipe recipeItem = _context.Recipe.Find(id);
            var retreivedIngredients = (
                from item in _context.IngredientsForRecipes
                where item.RecipeId == recipeItem.Id
                select item
                ).ToList();
            recipeItem.Ingredients = retreivedIngredients;
            var retreivedSteps = (
                from item in _context.StepsForRecipe
                where item.RecipeId == recipeItem.Id
                select item
                ).ToList();
            recipeItem.RecipeSteps = retreivedSteps;

            return View(recipeItem);
        }

        public ActionResult NewRandomRecipe([Bind(Include = "Id,apiId,title,image")] Recipe recipe)
        {
            Recipe prevRecipe = _context.Recipe.Find(recipe.Id);
            var newRecipe = rapidApiConnection.GetRandomRecipe();

                prevRecipe.apiId = newRecipe.recipes[0].id;
                prevRecipe.title = newRecipe.recipes[0].title;
                prevRecipe.image = newRecipe.recipes[0].image;
                prevRecipe.Saved = false;

            rapidApiConnection.GetRecipeInfoCall(prevRecipe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NewSimilarRecipe([Bind(Include = "Id,apiId,title,image")] Recipe recipe)
        {
            Recipe prevRecipe = _context.Recipe.Find(recipe.Id);
            var newRecipe = rapidApiConnection.GetSimilarRecipe(prevRecipe);

            prevRecipe.apiId = newRecipe.id;
            prevRecipe.title = newRecipe.title;
            prevRecipe.image = newRecipe.image;
            prevRecipe.Saved = false;

            rapidApiConnection.GetRecipeInfoCall(prevRecipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public void NewSearchByIngredients()
        {
            rapidApiConnection.SearchByIngredients();
        }

        public ActionResult NewMeals()
        {
            DeleteUnsavedRecipes();
            NewSearchByIngredients();
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void DeleteUnsavedRecipes()
        {
            var recipesToRemove = _context.Recipe.Where(p => p.Saved == false).ToList();
            foreach(var recipe in recipesToRemove)
            {
                _context.Recipe.Remove(recipe);
            }
            _context.SaveChangesAsync();
        }

        public ActionResult Saved(Recipe recipe)
        {
            Recipe savingRecipe = _context.Recipe.Find(recipe.Id);
            savingRecipe.Saved = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}