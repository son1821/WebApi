
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Net;
using WebApplication1.NewFolder;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public ActionResult<List<Product>> GetProducts()
        {
            return _services.GetProducts();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public ActionResult<Product> GetById(string id)
        {
            return _services.GetById(id);
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<Product> CreateProduct([FromBody]Product product)
        {

            return _services.Create(product);
        }
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult UpdateProduct(string id,[FromBody] Product product)
        {
           if(GetById(id) == null) {
            return NotFound($"Không tìm thấy product {id}");
            } 
            _services.Update(id,product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult DeleteProduct(string id)
        {
            if (GetById(id) == null)
            {
                return NotFound($"Không tìm thấy product {id}");
            }
            _services.Delete(id);
            return NoContent();
        }
    }
}
