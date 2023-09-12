using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductdto>> GetAllProduct()
        {
            string query = "Select * From Products";
            using (var connection=_context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductdto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory()
        {
            string query = "Select p.Id,Title,Price,City,District,Name as CategoryName From Products p Inner Join Categories c on p.CategoryId=c.Id";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}