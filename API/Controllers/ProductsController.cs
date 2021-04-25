using API.Core.DbModels;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Threading.Tasks;


namespace API.Controllers
{
    //https:localhost:5001/api/Products/GetProducts
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        
        [HttpGet] //http verbs -> GET POST DELETE PUT vs..
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _context.Products.ToListAsync();
            return data;
        }
    
        [HttpGet("{id}")]
        public ActionResult<Product> GetProducts(int id)
        {
            return _context.Products.Find(id);

        }

        


        

    }
}
