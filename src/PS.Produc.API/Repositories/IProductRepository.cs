using PS.Produc.API.Models;

namespace PS.Produc.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();        
        Task<Product> GetCategoryById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
