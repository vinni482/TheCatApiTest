using AutoMapper;
using Enums;
using TheCatApiTest.Models;
using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheCatApiTest.Services
{
    public class CatApiService : ICatApiService
    {
        private readonly ICatApiRepository _catApiRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CatApiService(ICatApiRepository catApiRepository, IConfiguration configuration, IMapper mapper)
        {
            _catApiRepository = catApiRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            string apiKey = _configuration[Configurations.ApiKey];
            var respose = await _catApiRepository.GetCategoriesAsync(apiKey);

            return respose.Data;
        }

        public async Task<PagedModel<Image>> GetImagesAsync(int categoryId, int limit, int page)
        {
            string apiKey = _configuration[Configurations.ApiKey];
            var response = await _catApiRepository.GetImagesAsync(apiKey, categoryId, limit, page);
            var result = _mapper.Map<PagedModel<Image>>(response);

            return result;
        }
    }
}
