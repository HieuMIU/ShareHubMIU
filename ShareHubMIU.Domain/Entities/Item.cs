using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ShareHubMIU.Domain.Entities
{
    public abstract class Item
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime DateListed { get; set; }
        public bool IsAvailable { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public required string SellerId { get; set; }

        [ForeignKey("SellerId")]
        [ValidateNever]
        public ApplicationUser Seller { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
    }

}
