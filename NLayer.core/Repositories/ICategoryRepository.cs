using NLayer.core.Repositories;
using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int cateoryId);
    }
}
