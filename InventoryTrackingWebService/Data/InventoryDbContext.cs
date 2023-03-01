
using System.Data.Entity;
using InventoryTrackingWebService.Models;

namespace InventoryTrackingWebService.Data
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}