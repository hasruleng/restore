using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {// we going to use inside this controller is we're going to use DI to get our store context inside here
    // so that we've got access to the products table in our database.
        

        //in order to use dependency injection, we create a private field inside our class and assign that private fields to the context that we're adding in our constructor here.
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context=context;

        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts(){
            var products=context.Products.ToList();
            return Ok(products);
        }
//api/products/3
        [HttpGet("{id}")]   
        public ActionResult<Product> GetProduct(int id){
            return context.Products.Find(id);
        }
    }
}