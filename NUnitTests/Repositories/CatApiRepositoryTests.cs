using Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository;
using System.Linq;
using System.Threading.Tasks;
using TheCatApiTest.Mappings;

namespace NUnitTests.Repositories
{
    public class CatApiRepositoryTests
    {
        private readonly ICatApiRepository _catApiRepository;
        private string _apiKey;

        public CatApiRepositoryTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICatApiRepository, CatApiRepository>();
            var serviceProvider = services.BuildServiceProvider();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _apiKey = config[Enums.Configurations.ApiKey];
            _catApiRepository = serviceProvider.GetService<ICatApiRepository>();            
        }

        [OneTimeSetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CategoriesListContainsItems()
        {
            var categories = await _catApiRepository.GetCategoriesAsync(_apiKey);
            Assert.IsTrue(categories.Data.Any());
        }

        [Test]
        [TestCase(4, 100)]
        public async Task GetImages_TotalCountIsPresentInHeaders(int categoryId, int limit)
        {
            var response = await _catApiRepository.GetImagesAsync(_apiKey, categoryId, limit, 0);
            int.TryParse(WebMappingProfile.GetTotalCountFromHeaders(response).ToString(), out int totalCount);
            Assert.GreaterOrEqual(totalCount, response.Data.Count);
        }

        [Test]
        [TestCase(4, 5)]
        [TestCase(4, 150)]
        public async Task GetImages_CheckLimit(int categoryId, int limit)
        {
            var response = await _catApiRepository.GetImagesAsync(_apiKey, categoryId, limit, 0);
            int.TryParse(WebMappingProfile.GetTotalCountFromHeaders(response).ToString(), out int totalCount);
            if (totalCount > limit)
                Assert.AreEqual(limit, response.Data.Count);
            else
                Assert.AreEqual(totalCount, response.Data.Count);
        }
    }
}
