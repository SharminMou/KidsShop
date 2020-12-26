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
    [Route("api/product/list")]
    [ApiController]
    public class FetchProductListController : ControllerBase
    {
        DatabaseContext db;
        public FetchProductListController()
        {
            db = new DatabaseContext();
        }
        //Fetch the list of products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.products.ToList();
        }

    }
}
