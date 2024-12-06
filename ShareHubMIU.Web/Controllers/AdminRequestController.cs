using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Implementations;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Web.ViewModel;
using System.Security.Claims;

namespace ShareHubMIU.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminRequestController : Controller
    {
        private readonly IRequestService _requestService;

        private readonly IItemService _itemService;

        private readonly UserManager<ApplicationUser> _userManager;

        public AdminRequestController(IRequestService requestService,
                                IItemService itemService,
                                UserManager<ApplicationUser> userManager)
        {
            _requestService =requestService;
            _itemService = itemService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var items = _requestService.GetAllRequests();

            return View(items);
        }

        public IActionResult Cancel(int itemId)
        {
            var request = _requestService.GetSingleItemById(itemId);
            request.Status = SD.ItemStatusCancelled;

            _requestService.UpdateRequest(request);
            TempData["success"] = "The Request has been cancelled successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewDetail(int itemId)
        {
            var request = _requestService.GetItemById(itemId);
            return View(request);
        }
    }
}
