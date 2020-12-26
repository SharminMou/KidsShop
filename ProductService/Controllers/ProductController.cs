using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Database;
using ProductService.Database.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DatabaseContext db;
        public ProductController()
        {
            db = new DatabaseContext();
        }
        //Fetch the list of products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                db.products.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model); //1id On success, return HTTP 201.
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex); //1ic for other errors, return HTTP 500.
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
