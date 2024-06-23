
using MongoDB.Driver;

namespace WebApplication1.NewFolder
{
    public class ProductServices : IProductServices
    {
        private readonly IMongoCollection<Product> _products;

        public ProductServices(IDatabaseSettings settings, IMongoClient mongoClient) {
        
        var database = mongoClient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ColectionName);
        }
        public Product Create(Product product)
        {
           _products.InsertOne(product);
            return product;
        }

        public void Delete(string id)
        {
           _products.DeleteOne(s => s.Id == id);

        }

        public Product GetById(string id)
        {
            return _products.Find(s => s.Id == id).FirstOrDefault();
            
        }

        public List<Product> GetProducts()
        {
           return _products.Find(s => true).ToList();
        }

        public void Update(string id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            _products.ReplaceOne(filter, product);
        }
    }
}
