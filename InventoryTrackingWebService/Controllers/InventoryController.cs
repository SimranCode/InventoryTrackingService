using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using InventoryTrackingWebService.Data;
using InventoryTrackingWebService.Models;

namespace InventoryTrackingWebService.Controllers
{
    public class InventoryController : ApiController
    {
       InventoryDbContext _dbContext = new InventoryDbContext();

        // GET /inventory
        public IHttpActionResult Get()
        {
            var inventory = _dbContext.InventoryItems;
            return Ok(inventory);
        }

        // GET /inventory/{name}
        [Route("api/Inventory/{name}")]
        public IHttpActionResult Get(string name)
        {
            var item = _dbContext.InventoryItems.FirstOrDefault(i => i.Name == name);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST /inventory
        public async Task<IHttpActionResult> Post( [FromBody]List<InventoryItem> items)
        {
            foreach (var item in items)
            {
                var existingItem = _dbContext.InventoryItems.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                    existingItem.ModifiedTime = DateTime.Now;
                }
                else
                {
                    item.CreatedOn = DateTime.Now;
                    _dbContext.InventoryItems.Add(item);
                }
            }

           await _dbContext.SaveChangesAsync();
            return Created(string.Empty, "Item is added in the inventory");
        }

        // PUT /inventory/{name}

        [Route("api/Inventory/{name}")]
        public IHttpActionResult Put(string name, [FromBody]InventoryItem item)
        {
            var existingItem = _dbContext.InventoryItems.FirstOrDefault(i => i.Name == name);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Quantity = item.Quantity;
                existingItem.ModifiedTime = DateTime.Now;
            }
            else
            {
                item.CreatedOn = DateTime.Now;
                _dbContext.InventoryItems.Add(item);
            }

            _dbContext.SaveChanges();
            return Ok();
        }

        // DELETE /inventory/{name}
        [Route("api/Inventory/{name}")]
        public async Task<IHttpActionResult> Delete(string name)
        {
            var item =  _dbContext.InventoryItems.FirstOrDefault(i => i.Name == name);
            if (item == null)
            {
                return NotFound();
            }
            _dbContext.InventoryItems.Remove(item);
          await _dbContext.SaveChangesAsync();
            return Ok("Item is deleted");
        }

        // GET /inventory/highest-quantity
        [HttpGet]
        [Route("api/inventory/highest-quantity")]
        public IHttpActionResult GetHighestQuantity()
        {
            var item = _dbContext.InventoryItems.OrderByDescending(i => i.Quantity).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // GET /inventory/lowest-quantity
        [HttpGet]
        [Route("api/inventory/lowest-quantity")]
        public IHttpActionResult GetLowestQuantity()
        {
            var item = _dbContext.InventoryItems.OrderBy(i => i.Quantity).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // GET /inventory/oldest-item
        [HttpGet]
        [Route("api/inventory/oldest-item")]
        public IHttpActionResult GetOldestItem()
        {
            var item = _dbContext.InventoryItems.OrderBy(i => i.CreatedOn).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // GET /inventory/newest-item
        [HttpGet]
        [Route("api/inventory/newest-item")]
        public IHttpActionResult GetNewestItem()
        {
            var item = _dbContext.InventoryItems.OrderByDescending(i => i.CreatedOn).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
