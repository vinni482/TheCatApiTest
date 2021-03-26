using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TheCatApiTest;
using TheCatApiTest.Models;

namespace NUnitTests.Mappings
{
    class RestResponseListImageToPagedModelImage
    {
        private readonly IMapper _mapper;
        IRestResponse<List<Image>> _response;

        public RestResponseListImageToPagedModelImage()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(Startup).Assembly);

            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _response = new RestResponse<List<Image>>
            {
                Data = new List<Image>
                {
                    new Image{ 
                        breeds = new List<object>(),
                        categories = new List<Category>{ new Category { id = 4, name = "sunglasses" } },
                        id = "16h",
                        url = "https://cdn2.thecatapi.com/images/16h.jpg",
                        height = 500,
                        width = 375
                    },
                    new Image{
                        breeds = new List<object>(),
                        categories = new List<Category>{ new Category { id = 4, name = "sunglasses" } },
                        id = "16g",
                        url = "https://cdn2.thecatapi.com/images/16g.jpg",
                        height = 700,
                        width = 228
                    }
                }
            };
            _response.Headers.Add(new Parameter(Enums.Headers.PaginationCount, 10, ParameterType.HttpHeader));
        }

        [Test]
        public void CheckImagesCountTheSameAfterMapping()
        {
            var result = _mapper.Map<PagedModel<Image>>(_response);
            Assert.AreEqual(_response.Data.Count, result.Items.Count);
        }

        [Test]
        public void CheckPaginationCountFromHeadersMoreThanZero()
        {
            var result = _mapper.Map<PagedModel<Image>>(_response);
            Assert.Greater(result.TotalCount, 0);
        }
    }
}
