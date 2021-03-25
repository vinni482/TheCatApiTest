using TheCatApiTest.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface ICatApiRepository
    {
        Task<IRestResponse<List<Category>>> GetCategoriesAsync(string apiKey);
        Task<IRestResponse<List<Image>>> GetImagesAsync(string apiKey, int categoryId, int limit, int page);
    }
}
