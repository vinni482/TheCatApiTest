using AutoMapper;
using Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheCatApiTest;
using TheCatApiTest.Models;
using TheCatApiTest.Services;

namespace NUnitTests.Services
{
    public class CatApiServiceTests
    {
        private readonly IMapper _mapper;
        private List<Category> _categories;
        private List<Image> _images;

        public CatApiServiceTests()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(Startup).Assembly);

            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _categories = new List<Category> { new Category{ id = 1, name = "hats" }, new Category{ id = 4, name = "sunglasses" }};
            _images = new List<Image> { new Image{ breeds = new List<object>(),
                                                   categories = _categories,
                                                   id = "16g",
                                                   url = "https://cdn2.thecatapi.com/images/16g.jpg",
                                                   height = 700,
                                                   width = 228
                                                 }
                                      };
        }

        [Test]
        public async Task GetCategoriesCount()
        {
            //Arrange
            var catApiRepoMock = new Mock<ICatApiRepository>();
            catApiRepoMock.Setup(x => x.GetCategoriesAsync(It.IsAny<string>())).ReturnsAsync(new RestResponse<List<Category>> { 
                Data = _categories
            });
            var configurationMock = new Mock<IConfiguration>();
            CatApiService catApiService = new CatApiService(catApiRepoMock.Object, configurationMock.Object, _mapper);

            //Act
            var categories = await catApiService.GetCategoriesAsync();

            //Assert
            Assert.AreEqual(_categories.Count, categories.Count);
        }

        [Test]
        public async Task GetImagesCount()
        {
            //Arrange
            var catApiRepoMock = new Mock<ICatApiRepository>();
            catApiRepoMock.Setup(x => x.GetImagesAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new RestResponse<List<Image>>
            {
                Data = _images
            });
            var configurationMock = new Mock<IConfiguration>();
            CatApiService catApiService = new CatApiService(catApiRepoMock.Object, configurationMock.Object, _mapper);

            //Act
            var images = await catApiService.GetImagesAsync(0, 0, 0);

            //Assert
            Assert.AreEqual(_images.Count, images.Items.Count);
        }
    }
}
