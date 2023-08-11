using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
	public interface ICategoryRepository
	{
		Task<List<ResultCategoryDto>> GetAllCategory();
		Task CreateCategory(CreateCategoryDto categoryDto);
		Task DeleteCategory(int categoryId);
		Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
		Task<GetCategoryByIdDto> GetCategoryById(int categoryId);
	}
}