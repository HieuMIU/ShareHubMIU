using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Web.ViewModel
{
    public class RoomSharingVM
    {
        public RoomSharing RoomSharing { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RoomTypes { get; set; }
    }
}
