using System.Diagnostics.Metrics;

namespace ServerSide.Model
{
    public class User
    {
       
        private static int counter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
  
        public User(string name, string address, string email, string password)
        {
            Id = ++counter;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Password = password;
        }
    }
}
