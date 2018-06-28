﻿using System;
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

        //On delete, also delete ingredients with recipeId (X)
        //on ShoppingList click, query IngredientName not found in FoodItems table (X)
        //if IngredientName already exists in shoppingList, then add quantity
        //On actionlink click, transfer item to fridge table, and delete from shopping list
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
            RapidApiConnection rapidApiConnection = new RapidApiConnection();
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
            RapidApiConnection rapidApiConnection = new RapidApiConnection();
            var newRecipe = rapidApiConnection.GetSimilarRecipe(prevRecipe);

            prevRecipe.apiId = newRecipe.id;
            prevRecipe.title = newRecipe.title;
            prevRecipe.image = newRecipe.image;
            prevRecipe.Saved = false;

            rapidApiConnection.GetRecipeInfoCall(prevRecipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Saved(Recipe recipe)
        {
            Recipe savingRecipe = _context.Recipe.Find(recipe.Id);
            savingRecipe.Saved = true;
            _context.SaveChanges();
            return View("Index");
        }

    }
}