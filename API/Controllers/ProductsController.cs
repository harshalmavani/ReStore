using System.Text.Json;
using API.Data;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	public class ProductsController : BaseController
	{
		private readonly StoreContext _storeContext;

		public ProductsController(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] ProductParams productParams)
		{
			var query = _storeContext.Products
				.Sort(productParams.OrderBy)
				.Search(productParams.SearchTerm)
				.Filter(productParams.Brands, productParams.Types)
				.AsQueryable();

			var products = await PagedList<Product>.toPagedList(query,
				productParams.PageNumber, productParams.PageSize);

			Response.AddPaginationHeader(products.MetaData);

			return products;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await _storeContext.Products.FindAsync(id);
			if (product is null) return BadRequest(new ProblemDetails { Title = "Product not found" });
			return product;
		}

		[HttpGet("filters")]
		public async Task<IActionResult> GetFilters()
		{
			var brands = await _storeContext.Products.Select(p => p.Brand).Distinct().ToListAsync();
			var types = await _storeContext.Products.Select(p => p.Type).Distinct().ToListAsync();

			return Ok(new { brands, types });
		}
	}
}