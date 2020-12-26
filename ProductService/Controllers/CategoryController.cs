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
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        DatabaseContext db;
        public CategoryController()
        {
            db = new DatabaseContext();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Category model)
        {
            try
            {
                    db.category.Add(model);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, model); 

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
