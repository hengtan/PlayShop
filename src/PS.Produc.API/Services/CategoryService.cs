using AutoMapper;
using PS.Produc.API.DTOs;
using PS.Produc.API.Models;
using PS.Produc.API.Repositories;
using PS.Produc.API.Services.Interfaces;

namespace PS.Produc.API.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoryEntity);
            categoryDTO.CategoryId = categoryEntity.CategoryId;
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task DeleteCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetCategoryById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }
    }
}
