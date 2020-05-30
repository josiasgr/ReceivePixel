using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using receivePixel.Models;
using receivePixel.Services;
using System.Linq;
using System.Threading.Tasks;

namespace receivePixel.Controllers
{
    [Route("")]
    [ApiController]
    public class ReceiveController : ControllerBase
    {
        private readonly IStorageService<Pixel> _pixelStorageService;

        public ReceiveController(
            IStorageService<Pixel> pixelStorageService)
        {
            _pixelStorageService = pixelStorageService;
        }

        [HttpGet]
        public Task GetAsync()
        {
            if (Request.Query.Any())
            {
                return _pixelStorageService.SaveAsync(new Pixel
                {
                    QueryString = Request.QueryString.ToString(),
                    Headers = Request.Headers.ToDictionary(k => k.Key, v => v.Value.ToString()),
                    Query = Request.Query.ToDictionary(k => k.Key, v => v.Value.ToString())
                });
            }
            return Task.CompletedTask;
        }
    }
}