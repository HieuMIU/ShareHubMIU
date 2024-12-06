using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Web.ViewModel;
using Syncfusion.Presentation;

namespace ShareHubMIU.Web.Controllers
{
    [Authorize(Roles = SD.Role_Customer)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IItemService _itemService;

        public HomeController(ILogger<HomeController> logger, 
                                IWebHostEnvironment webHostEnvironment,
                                IItemService itemService)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Items = _itemService.GetAllItems(status: SD.ItemStatusAvailable.ToString()),
                Type = null,
                Categories = new List<string>()
                {
                    SD.CategoryTypeCarSharing.ToString(),
                    SD.CategoryTypeRoomSharing.ToString(),
                    SD.CategoryTypeElectronics.ToString(),
                    SD.CategoryTypeFuniture.ToString(),
                    SD.CategoryTypeMiscellaneous.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult GetItemsByType(string type)
        {

            HomeVM homeVM = new()
            {
                Items = _itemService.GetAllItems(status: SD.ItemStatusAvailable.ToString(), type: type),
                Type = type,
                Categories = new List<string>()
                {
                    SD.CategoryTypeCarSharing.ToString(),
                    SD.CategoryTypeRoomSharing.ToString(),
                    SD.CategoryTypeElectronics.ToString(),
                    SD.CategoryTypeFuniture.ToString(),
                    SD.CategoryTypeMiscellaneous.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return PartialView("_ItemList", homeVM);
        }
    }
}
