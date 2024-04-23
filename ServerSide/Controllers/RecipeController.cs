using Microsoft.AspNetCore.Mvc;
using ServerSide.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public static int counter = 3;

        public static List<Recipe> recipes = new List<Recipe>
        {
            new Recipe("Recipe1", new Category( "Category1", "Description1"), 30, 2, DateTime.Now, new List<Ingredient> { new Ingredient("Ingredient1", "https://img.freepik.com/free-vector/onion-illustration-vector-design-silhouette_343694-1245.jpg?t=st=1713303842~exp=1713307442~hmac=9a6608a1bb07f676a6540b81a1f19ee75c7af6379151019d43c4f00364ffbf5b&w=900"), new Ingredient("Ingredient2", "fjd") }, new List<string> { "Step1", "Step2" }, "user123", "image1"),
            new Recipe("Recipe2", new Category("Category2", "Description2"), 45, 3, DateTime.Now, new List<Ingredient> { new Ingredient("Ingredient3", "fjd"), new Ingredient("Ingredient4", "fjd") }, new List<string> { "Step3", "Step4" }, "user456", "image2"),
        };

        // GET: api/<RecipeController>
        [HttpGet]
         public IEnumerable<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        [HttpGet("counter")]
        public int GetCounter()
        {
            return counter;
        }
        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = recipes.Find(r => r.RecipeCode == id);
            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpGet("by-user-code/{userCode}")]
        public IActionResult GetRecipesByUserCode(string userCode)
        {
            var userRecipes = recipes.Where(r => r.UserCode == userCode).ToList();
            if (userRecipes.Count == 0)
                return NotFound("No recipes found for this user.");

            return Ok(userRecipes);
        }

        // POST api/<RecipeController>
        [HttpPost]
        public IActionResult Post([FromBody] Recipe newRecipe)
        {
            if (newRecipe == null)
                return BadRequest("Invalid data.");
            counter = ++counter;
            recipes.Add(newRecipe);
            return Ok(true);
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Recipe updatedRecipe)
        {
            Recipe recipeToUpdate = recipes.FirstOrDefault(r => r.RecipeCode == id);
            if (recipeToUpdate != null)
            {
                recipeToUpdate.RecipeName = updatedRecipe.RecipeName;
                recipeToUpdate.Category = updatedRecipe.Category;
                recipeToUpdate.PreparationTimeMinutes = updatedRecipe.PreparationTimeMinutes;
                recipeToUpdate.DifficultyLevel = updatedRecipe.DifficultyLevel;
                recipeToUpdate.DateAdded = updatedRecipe.DateAdded;
                recipeToUpdate.Ingredients = updatedRecipe.Ingredients;
                recipeToUpdate.PreparationMethod = updatedRecipe.PreparationMethod;
                recipeToUpdate.UserCode = updatedRecipe.UserCode;
                recipeToUpdate.ImageUrl = updatedRecipe.ImageUrl;

                return Ok(true);
            }
            return NotFound();
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var recipe = recipes.Find(r => r.RecipeCode == id);
            if (recipe != null)
            {
                recipes.Remove(recipe);
                return Ok(true);
            }
            return NotFound();
        }
    }
}
