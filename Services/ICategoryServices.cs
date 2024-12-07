using ShoppingNet.API.DTOs;

namespace ShoppingNet.API.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<IEnumerable<CategoryDto>> GetAllCategoriesProducts();
        Task<CategoryDto> GetCategoryById(int id);
        Task AddCategory(CategoryDto categoryDto);
        Task UpdateCategory(CategoryDto categoryDto);
        Task RemoveCategory(int id);
    }
}
