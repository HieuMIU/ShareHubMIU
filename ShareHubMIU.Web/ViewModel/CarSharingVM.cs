using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Web.ViewModel
{
    public class CarSharingVM
    {
        public CarSharing CarSharing { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? Conditions { get; set; }
    }
}
