using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime DateListed { get; set; }
        public bool IsAvailable { get; set; }

        [Required]
        public string SellerId { get; set; }

        [ForeignKey("SellerId")]
        public ApplicationUser seller { get; set; }
    }

}
