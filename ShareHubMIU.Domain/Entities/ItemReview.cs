using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Domain.Entities
{
    public class ItemReview
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Type { get; set; }

        public string Note { get; set; }

        public int Rating { get; set; }
    }
}
