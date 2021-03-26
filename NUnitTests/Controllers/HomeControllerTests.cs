using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCatApiTest.Controllers;
using TheCatApiTest.Models;

namespace NUnitTests.Controllers
{
    public class HomeControllerTests
    {
        private List<Category> _categories;
        private List<Image> _images;
        private PagedModel<Image> _imagePagedModel;

        [OneTimeSetUp]
        public void Setup()
        {
            _categories = new List<Category> { new Category { id = 1, name = "hats" }, new Category { id = 4, name = "sunglasses" } };
            _images = new List<Image> { new Image{ breeds = new List<object>(),
                                                   categories = _categories,
                                                   id = "16g",
                                                   url = "https://cdn2.thecatapi.com/images/16g.jpg",
                                                   height = 700,
                                                   width = 228
                                                 }
                                      };
            _imagePagedModel = new PagedModel<Image> { Items = _images, TotalCount = _images.Count };
        }

        [Test]
        public async Task GetCategories_OK()
        {
            //Arrange
            var catApiServiceMock = new Mock<ICatApiService>();
            catApiServiceMock.Setup(x => x.GetCategoriesAsync()).ReturnsAsync(_categories);
            HomeController homeController = new HomeController(catApiServiceMock.Object);
            
            //Act
            var res = await homeController.GetCategories();

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(res.Result);
        }

        [Test]
        public async Task GetImages_OK()
        {
            //Arrange
            var catApiServiceMock = new Mock<ICatApiService>();
            catApiServiceMock.Setup(x => x.GetImagesAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(_imagePagedModel);
            HomeController homeController = new HomeController(catApiServiceMock.Object);

            //Act
            var res = await homeController.GetImages(0, 0, 0);

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(res.Result);
        }
    }
}
