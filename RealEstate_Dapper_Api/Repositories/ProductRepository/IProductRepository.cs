using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
	public interface IProductRepository
	{
		Task<List<ResultProductdto>> GetAllProduct();
		Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory();
	}
}