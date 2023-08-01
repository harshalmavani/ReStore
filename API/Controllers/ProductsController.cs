using API.Data;
using API.Entities;
using API.Extensions;
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
		public async Task<ActionResult<List<Product>>> GetProducts(string orderBy, string searchTerm, string brands, string types)
		{
			var query = _storeContext.Products
				.Sort(orderBy)
				.Search(searchTerm)
				.Filter(brands, types)
				.AsQueryable();

			return await query.ToListAsync();
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await _storeContext.Products.FindAsync(id);
			if (product is null) return BadRequest(new ProblemDetails { Title = "Product not found" });
			return product;
		}
	}
}