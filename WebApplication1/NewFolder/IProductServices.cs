namespace WebApplication1.NewFolder
{
    public interface IProductServices
    {
        Product GetById(int id);
        List<Product> GetProducts();
        void Create(Product product);
        void Update(int id,Product product);
        void Delete(int id);    
    }
}
