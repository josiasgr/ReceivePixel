using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using receivePixel.Models;
using receivePixel.Services;
using System;
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
        public async Task<FileContentResult>  GetAsync()
        {
            if (Request.Query.Any())
            {
                await _pixelStorageService.SaveAsync(new Pixel
                {
                    QueryString = Request.QueryString.ToString(),
                    Headers = Request.Headers.ToDictionary(k => k.Key, v => v.Value.ToString()),
                    Query = Request.Query.ToDictionary(k => k.Key, v => v.Value.ToString())
                });

            }

            //return empty gif
            const string clearGif1X1 = "R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==";
            return new FileContentResult(
                               Convert.FromBase64String(clearGif1X1), "image/gif");
        }
    }
}