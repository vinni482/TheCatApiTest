using TheCatApiTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICatApiService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<PagedModel<Image>> GetImagesAsync(int categoryId, int limit, int page);
    }
}
