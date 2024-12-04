using Microsoft.AspNetCore.Http;
using ShareHubMIU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Domain.View
{
    public class ItemView
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }
        public DateTime DateListed { get; set; }
        public bool IsAvailable { get; set; }
      
        public string? ImageUrl { get; set; }
    }
}
