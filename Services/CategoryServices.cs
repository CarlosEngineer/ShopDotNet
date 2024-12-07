using AutoMapper;
using ShoppingNet.API.DTOs;
using ShoppingNet.API.Models;
using ShoppingNet.API.Repositories;

namespace ShoppingNet.API.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDto categoryDto)
        {
           var categoryEntity = _mapper.Map < Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var categoriesEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(categoriesEntity);
        }

        public async Task RemoveCategory(int id)
        {
            var categoriesEntity =  _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoriesEntity.CategoryId);
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
