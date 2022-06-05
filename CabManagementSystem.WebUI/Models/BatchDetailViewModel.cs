using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.WebUI.Models
{
    public class BatchDetailViewModel
    {
        public IEnumerable<BatchDetail> BatchDetails { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}