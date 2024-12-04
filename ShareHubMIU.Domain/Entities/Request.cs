using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Type { get; set; }

        [Required]
        public string BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public ApplicationUser Buyer { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpiredDate { get; set; }

    }
}
