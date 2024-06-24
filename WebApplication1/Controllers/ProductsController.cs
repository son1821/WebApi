
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
        public ActionResult<Product> GetById(int id)
        {
            return _services.GetById(id);
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult CreateProduct([FromBody]Product product)
        {

            _services.Create(product);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult UpdateProduct(int id,[FromBody] Product product)
        {
           if(GetById(id) != null)
            {
                _services.Update(id,product);

            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult DeleteProduct(int id)
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
