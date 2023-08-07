using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		readonly ICategoryRepository _categoryRepository;
		public CategoriesController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategoryList()
		{
			var result = await _categoryRepository.GetAllCategoryAsync();
			return Ok(result);
		}
	}
}