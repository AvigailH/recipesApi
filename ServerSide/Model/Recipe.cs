namespace ServerSide.Model
{
    public class Recipe
    {
        private static int counter = 0;
        public int RecipeCode { get; set; }
        public string RecipeName { get; set; }
        public Category Category { get; set; } // Updated to use Category object
        public int PreparationTimeMinutes { get; set; }
        public int DifficultyLevel { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> PreparationMethod { get; set; }
        public string UserCode { get; set; }
        public string ImageUrl { get; set; } // Updated property name

        public Recipe(string recipeName, Category category, int preparationTimeMinutes, int difficultyLevel, DateTime dateAdded, List<Ingredient> ingredients, List<string> preparationMethod, string userCode, string imageUrl)
        {
            RecipeCode = ++counter;
            RecipeName = recipeName;
            Category = category;
            PreparationTimeMinutes = preparationTimeMinutes;
            DifficultyLevel = difficultyLevel;
            DateAdded = dateAdded;
            Ingredients = ingredients;
            PreparationMethod = preparationMethod;
            UserCode = userCode;
            ImageUrl = imageUrl;
        }
    }
}
