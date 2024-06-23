namespace WebApplication1.NewFolder
{
    public interface IProductServices
    {
        Product GetById(string id);
        List<Product> GetProducts();
        Product Create(Product product);
        void Update(string id,Product product);
        void Delete(string id);    
    }
}
