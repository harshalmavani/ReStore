using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.RequestHelpers
{
	public class PagedList<T> : List<T>
	{
		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			MetaData = new MetaData
			{
				TotalCount = count,
				CurrentPage = pageNumber,
				PageSize = pageSize,
				TotalPages = (int)Math.Ceiling(count / (double)pageSize)
			};
			AddRange(items);
		}

		public MetaData MetaData { get; set; }

		public static async Task<PagedList<T>> toPagedList(IQueryable<T> query, int pageNumber, int pageSize)
		{
			var count = await query.CountAsync();
			var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}