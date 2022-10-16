using Microsoft.AspNetCore.Mvc;
using MongoDBTutorial.Models;
using MongoDBTutorial.Services;

namespace MongoDBTutorial.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FavoriteController : Controller
    {
        private readonly MongoDbService _mongoDbService;

        public FavoriteController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<List<Developer>> Get()
        {
            return await _mongoDbService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Developer developer)
        {
            await _mongoDbService.CreateAsync(developer);

            return CreatedAtAction(nameof(Get), new { id = developer.Id }, developer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToFavLanguages(string id, [FromBody] string languageId)
        {
            await _mongoDbService.AddToFavLanguagesAsync(id, languageId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDbService.DeleteAsync(id);
            return NoContent();
        }

    }
}
