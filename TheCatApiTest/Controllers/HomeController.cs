using TheCatApiTest.Models;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheCatApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICatApiService _catApiService;

        public HomeController(ICatApiService catApiService)
        {
            _catApiService = catApiService;
        }

        [HttpGet]
        [Route("/categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var result = await _catApiService.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("/images")]
        public async Task<ActionResult<PagedModel<Image>>> GetImages(int categoryId, int limit = 5, int page = 1)
        {
            var result = await _catApiService.GetImagesAsync(categoryId, limit, page);
            return Ok(result);
        }
    }
}
