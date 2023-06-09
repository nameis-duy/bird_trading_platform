﻿using BirdTrading.Domain.Models;
using BirdTrading.Utils.Pagination;

namespace BirdTrading.Interface.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Pagination<Product>> SearchProductPagingAsync(string search, int pageIndex, int pageSize);
        Task<IEnumerable<Product>> GetTop4RelateProductAsync(int categoryType, int productId);
    }
}
