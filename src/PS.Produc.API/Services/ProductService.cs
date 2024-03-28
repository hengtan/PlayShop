using AutoMapper;
using PS.Produc.API.DTOs;
using PS.Produc.API.Models;
using PS.Produc.API.Repositories;
using PS.Produc.API.Services.Interfaces;

namespace PS.Produc.API.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);           
        }

        public async Task<ProductDTO> GetProductsById(int id)
        {
            var productEntity = await _productRepository.GetCategoryById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task AddProduct(ProductDTO productDTO)
        {            
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.Create(productEntity);
            productDTO.CategoryId = productEntity.CategoryId;
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.Update(productEntity);
        }        

        public async Task DeleteProduct(int id)
        {
            var categoryEntity = _productRepository.GetCategoryById(id).Result;
            await _productRepository.Delete(categoryEntity.CategoryId);
        }
    }
}
