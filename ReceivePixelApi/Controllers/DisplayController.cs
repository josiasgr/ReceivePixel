using Microsoft.AspNetCore.Mvc;
using receivePixel.Models;
using receivePixel.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace receivePixel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DisplayController : ControllerBase
    {
        private readonly IStorageService<Pixel> _pixelStorageService;

        public DisplayController(
            IStorageService<Pixel> pixelStorageService)
        {
            _pixelStorageService = pixelStorageService;
        }

        [HttpGet]
        [Route("{top:int:min(1):max(1000)}")]
        public Task<IEnumerable<Pixel>> GetAsync(int top)
        {
            return _pixelStorageService.ReadTopAsync(top, "Timestamp", OrderByDirection.Descending);
        }
    }
}