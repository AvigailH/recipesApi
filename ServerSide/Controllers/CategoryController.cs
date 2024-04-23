using Microsoft.AspNetCore.Mvc;
using ServerSide.Model;
using System.Collections.Generic;
using System.Linq;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static int Counter = 3;
        public static List<Category> categories = new List<Category>
        {
            new Category("Salads", "https://www.flaticon.com/free-icons/salad"),
            new Category("Meet", "https://www.flaticon.com/free-icons/steak"),
            new Category("Desert", "https://www.flaticon.com/free-icons/desert")

        };

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }

        // GET api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Category1 = categories.Find(u => u.Id == id);
            if (Category1 == null)
                return NotFound();

            return Ok(Category1);
        }

        // GET api/Category/name={name}
        [HttpGet("name={name}")]
        public IEnumerable<Category> GetByName(string name)
        {
            return categories.Where(s => s.Name.Contains(name));
        }

        // POST api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category newCategory)
        {
            if (newCategory == null)
                return BadRequest("Invalid data.");

            newCategory.Id = Counter++;

            categories.Add(newCategory);
            return Ok(true);
        }

        // PUT api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category updatedCategory)
        {
            Category categoryToUpdate = categories.FirstOrDefault(s => s.Id == id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = updatedCategory.Name;
                categoryToUpdate.Icon = updatedCategory.Icon;

                return Ok(true);
            }
            return NotFound();
        }

        // DELETE api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Category = categories.Find(s => s.Id == id);
            if (Category != null)
            {
                categories.Remove(Category);
                return Ok(true);
            }
            return NotFound();
        }
    }
}
