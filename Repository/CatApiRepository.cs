using Enums;
using TheCatApiTest.Models;
using Interfaces.Repository;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class CatApiRepository : ICatApiRepository
    {
        private RestClient _client;

        public CatApiRepository()
        {
            _client = new RestClient("https://api.thecatapi.com/v1");
        }

        public async Task<IRestResponse<List<Category>>> GetCategoriesAsync(string apiKey)
        {
            var request = new RestRequest("categories", Method.GET);
            request.AddHeader(Headers.ApiKey, apiKey);
            var queryResult = await _client.ExecuteAsync<List<Category>>(request);

            return queryResult;
        }

        public async Task<IRestResponse<List<Image>>> GetImagesAsync(string apiKey, int categoryId, int limit, int page)
        {
            var request = new RestRequest("images/search", Method.GET);
            request.AddHeader(Headers.ApiKey, apiKey);
            request.AddParameter("category_ids", categoryId);
            request.AddParameter("page", page);
            request.AddParameter("limit", limit);
            request.AddParameter("order", "Desc");
            var queryResult = await _client.ExecuteAsync<List<Image>>(request);

            return queryResult;
        }
    }
}
