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
    [Route("api/product/add")]
    [ApiController]
    public class AddProductController : ControllerBase
    {
        DatabaseContext db;
        public AddProductController()
        {
            db = new DatabaseContext();
        }
 

        // POST api/<AddProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                if(db.products.Any(c => c.name == model.name))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, model); //If the name is duplicate, should return HTTP 400
                }

                else
                {
                    db.products.Add(model);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, model); //1id On success, return HTTP 201

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex); //1ic for other errors, return HTTP 500
            }
        }

    }
}
