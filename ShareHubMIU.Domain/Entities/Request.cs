using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ShareHubMIU.Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        [ValidateNever]
        public Item? Item { get; set; }

        [Required]
        public string BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        [ValidateNever]
        public ApplicationUser? Buyer { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpiredDate { get; set; }

    }
}
