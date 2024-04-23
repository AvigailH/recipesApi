namespace ServerSide.Model
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public Ingredient(string name, string icon)
        {
            this.Name = name;
            this.Icon = icon;
        }
    }
}