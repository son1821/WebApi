


using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication1.NewFolder
{
    public class ProductServices : IProductServices
    {
        private readonly ProductDbContext _productDbContext;

        public ProductServices(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void Create(Product product)
        {
            
            _productDbContext.Products.Add(product);
           
            _productDbContext.SaveChanges();
         
        }

        public void Delete(int id)
        {
           var result = _productDbContext.Remove(id);
            _productDbContext.SaveChanges();

        }

        public Product GetById(int id)
        {
          var product = _productDbContext.Products.Find(id);
            if (product == null)
            {
                return null ;
            }
            return product;
        }

        public List<Product> GetProducts()
        {
           return _productDbContext.Products.ToList();
        }

        public void Update(int id,Product updateProduct)
        {
            var productDbcontex = _productDbContext.Products.Find(id);
            if(productDbcontex != null && id == productDbcontex.Id)
            {
                _productDbContext.Entry(productDbcontex).CurrentValues.SetValues(updateProduct);
                _productDbContext.SaveChanges();
            }
             
            
            
        }
    }
}
