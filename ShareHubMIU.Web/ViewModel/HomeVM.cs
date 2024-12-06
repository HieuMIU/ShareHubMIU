using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Web.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Item> Items { get; set; }

        public string Type { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
