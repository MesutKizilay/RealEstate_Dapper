using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
	public class CategoryRepository : ICategoryRepository
	{
		readonly Context _context;
		public CategoryRepository(Context context)
		{
			_context = context;
		}

		public async Task CreateCategory(CreateCategoryDto createCategoryDto)
		{
			string query = "Insert Into Categories (Name,Status) Values (@categoryName,@categoryStatus)";

			var parameters = new DynamicParameters();
			parameters.Add("@categoryName", createCategoryDto.CategoryName);
			parameters.Add("@categoryStatus", true);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteCategory(int categoryId)
		{
			string query = "Delete From Categories Where Id=@categoryId";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryId", categoryId);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultCategoryDto>> GetAllCategory()
		{
			string query = "Select * From Categories";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultCategoryDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetCategoryByIdDto> GetCategoryById(int id)
		{
			string query = "Select * From Categories Where Id=@categoryId";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryId", id);

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetCategoryByIdDto>(query, parameters);
				return values;
			}
		}

		public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			string query = "Update Categories Set Name=@categoryName,Status=@categoryStatus Where Id=@categoryId";
			var parameters = new DynamicParameters();
			parameters.Add("categoryName", updateCategoryDto.Name);
			parameters.Add("categoryStatus", updateCategoryDto.Status);
			parameters.Add("categoryId", updateCategoryDto.Id);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}