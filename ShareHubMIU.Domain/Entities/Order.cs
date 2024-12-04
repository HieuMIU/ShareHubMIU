using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int RequestId { get; set; }

        [ForeignKey("RequestId")]
        public Request Request { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public bool IsPaid { get; set; }

    }
}
