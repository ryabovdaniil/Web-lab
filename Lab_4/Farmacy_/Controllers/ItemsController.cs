using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Farmacy_.Models;
using System.Threading.Tasks;

namespace Farmacy_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        ItemsContext db;
        public ItemsController(ItemsContext context)
        {
            db = context;
            if (!db.Items.Any())
            {
                db.Items.Add(new Item { Name = "Парацетамол", Company = "фарм", Price = 200  });
                db.Items.Add(new Item { Name = "Каметон", Company = "фарм", Price = 250 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return await db.Items.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            Item item = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }


        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            db.Items.Add(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }


        [HttpPut]
        public async Task<ActionResult<Item>> Put(Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            if (!db.Items.Any(x => x.Id == item.Id))
            {
                return NotFound();
            }

            db.Update(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            Item item = db.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }
    }
}