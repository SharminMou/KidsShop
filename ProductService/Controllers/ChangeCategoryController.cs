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
    [Route("api/product/updateCategory")]
    [ApiController]
    public class ChangeCategoryController : ControllerBase
    {
        DatabaseContext db;
        public ChangeCategoryController()
        {
            db = new DatabaseContext();
        }
        
        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        


        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Update([FromBody] Product model)
        {
            try
            {
                Product thisProduct = db.products.Find(model.id);
                thisProduct.categoryId = model.categoryId;
                thisProduct.categoryName = model.categoryName;
                db.products.Update(thisProduct);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex);
            }
        }

      
    }
}
