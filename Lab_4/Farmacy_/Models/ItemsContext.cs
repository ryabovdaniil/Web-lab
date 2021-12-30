using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Farmacy_.Models
{
    public class ItemsContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ItemsContext(DbContextOptions<ItemsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}