using Microsoft.AspNetCore.Mvc;
using ServerSide.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> Users = new List<User>
        {
            new User ("avraham","Amit Meir 10","gyui@gmail.com", "245w6du"),
            new User ("אביגיל","Amit Meir 10","gyui@gmail.com", "1234"),
            new User ("yosi", "Rabi Akiva 64", "bjkl@gmail.com", "8950blf"),
            new User ("eden", "raziel 95", "huigle@gmail.com", "njgkw853"),
        };

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            User newUser = new User(value.Name, value.Address, value.Email, value.Password);
            Users.Add(newUser);
            return Ok(Users);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            var existingUser = Users.Find(u => u.Id == id);
            if (existingUser == null)
                return Ok(Users);

            // Update user properties
            existingUser.Name = updatedUser.Name;
            existingUser.Address = updatedUser.Address;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;

            return Ok(Users);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = Users.Find(u => u.Id == id);
            if (existingUser == null)
                return NotFound();
            else
                Users.Remove(existingUser);
            return Ok(Users);
        }
    }
}