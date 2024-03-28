using PS.Produc.API.DTOs;

namespace PS.Produc.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();        
        Task<ProductDTO> GetProductsById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(ProductDTO productDTO);
        Task DeleteProduct(int id);
    }
}
