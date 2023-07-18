using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Extensions;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResources()
        {
            var response = await _advertisementService.GetAdvertisementListAsync();
            return this.ResponseView(response);
        }
    }
}
