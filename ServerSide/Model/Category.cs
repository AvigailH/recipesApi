namespace ServerSide.Model
{
    public class Category
    {
        private static int counter = 0;

        public int Id { get; set; }  
        public string Name { get; set; }
        public string Icon { get; set; }

        public Category(string name, string icon)
        {
            Id = ++counter;
            this.Name = name;
            this.Icon = icon;
        }
    }
}
