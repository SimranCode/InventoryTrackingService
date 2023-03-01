using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTrackingWebService.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }

}