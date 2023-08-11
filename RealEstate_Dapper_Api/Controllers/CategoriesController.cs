using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
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
			var result = await _categoryRepository.GetAllCategory();
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			await _categoryRepository.CreateCategory(createCategoryDto);
			return Ok("Kategori başarılı bir şekilde eklendi");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(int categoryId)
		{
			await _categoryRepository.DeleteCategory(categoryId);
			return Ok("Kategori başarılı bir şekilde silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryRepository.UpdateCategory(updateCategoryDto);
			return Ok("Kategori başarılı bir şekilde güncellendi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(int id)
		{
			var result =await _categoryRepository.GetCategoryById(id);
			return Ok(result);
		}
	}
}