using CoreBusiness;

namespace UseCases.DataStorepluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId, bool loadCategory=false);
        IEnumerable<Product> GetProducts(bool loadCategory);
        IEnumerable<Product> GetProductsByCategory(int categoryId); 
        void UpdateProduct(int productId, Product product);
    }
}