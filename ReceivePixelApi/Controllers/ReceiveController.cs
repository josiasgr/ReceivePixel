using Microsoft.AspNetCore.Mvc;
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
            const string clearGif1X1 = "R0lGODlhMAAwAOfEAKoAAKoBAaoCAqoDA6sDA6sEBKsFBawGBqwHB6wICK0JCa0KCq0LC60MDK4MDK4NDa4ODq4PD68PD64QEK8SErASErAUFLEVFbEWFrEXF7IZGbIaGrMdHbQeHrQfH7QgILQhIbUhIbUiIrUjI7YkJLYlJbYmJrcqKrgrK7gsLLkuLrkvL7kwMLs1Nbw4OL05Ob06Or49Pb5AQL9AQL9CQsBDQ8FGRsFHR8FJScJKSsJLS8NLS8NNTcROTsRRUcRSUsVSUsVUVMZVVcdYWMdZWcdbW8hbW8hcXMleXslfX8tnZ8xpac1qas1ra81sbM1tbc9xcc9zc9Bzc9B0dNB1ddF2dtF5edJ5edJ6etJ7e9N8fNN9fdWDg9aEhNaGhteIiNiMjNmOjtmPj9mRkdqSktqTk9qUlNuUlNuVlduWltyXl9yYmNyZmdyamt2dnd6ent6fn9+iouCiouCjo+CkpOClpeCmpuGmpuKqquKrq+Orq+KsrOOtrea0tOa1tea2tua3t+e4uOe5uee7u+i9vem+vum/v+nBwerBwerDw+vExOvFxevGxuzJye3Jye3Kyu3Ly+7Nze7Pz+7Q0O/R0e/S0vDT0/DU1PDW1vHW1vHX1/LZ2fLa2vLb2/Pd3fPe3vTe3vPf3/Tf3/Tg4PTh4fXi4vXj4/bk5Pbl5fbm5vbn5/fp6ffq6vjr6/nt7fnu7vnv7/nw8Prw8Prx8fry8vrz8/vz8/v09Pv19fv29vz29vz39/z4+Pz5+f35+f36+v37+/78/P79/f7+/v///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////yH5BAEKAP8ALAAAAAAwADAAAAj+AIkJHEiwoMGDCBMqXMiwocOHECNKnEixosWLGC0Kk+VqWEaFwmCV2qSpkypevvIUKSPsY8Fhr/I0iXGCRIgPIkyooPGBTCyXA399mmIBgFEABhQ8kCDhAAAEAVDg+eUyV5gNRiO8QKLlzB0/hP6s0MCGi5EZk1yKcQCAQpZIp2i1HJgIw5JhwmaNsvUxlAEERloh/LVFgCOgA8EckHIr4SoWKYIhFkhlQymFfghgmSzQjQuPCIcFGXCIM7FPLgQjNLWAhCjTw+x42YUQDYAdsEwTA1YHyifQA4HVCDBlLmxOgYAVzNSBgZhCcMT00W1wGJ0FAlJQ2fPIEnWBwFj+AUoyAcCITN8H7iJkxckXPSAApEkvEBMRIX5SBeNDwMKs78KkosUIZdC2WwwAVPHdLm/YEAUnwAkSwAWSULfKER7IgQtBvdwAABC0wAZKDh808hIiFzAgh2nCALKCC5QYpAsTAcjw02TDGCICB48YNxAlFAjAiGmbrACBIgf5okMASpjmSQsQxHHQMLadwAlnuPgQABG1HHRJCQmIoRxiw/ABQQWFHITLEwHgoAtntAwBAA9UGbRGAzKgYtopGQAwx0GDSIBCJbpJYhQkBQlDCQgcAALcZJEY9UdBisAwwyKPTmYKVj/4ItAuZnhAxGsLXoFAAT200YULHIzhKX0erqghBAwxHGEGKfQRFBIqqcziY67ABivssMQWC1RAADs=";
            return new FileContentResult(
                               Convert.FromBase64String(clearGif1X1), "image/gif");
        }
    }
}