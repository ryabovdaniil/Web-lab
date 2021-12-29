using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Farmacy.Models
{
    public class Order
    {
        public int OrderId { get; set; }
      
        public string Person { get; set; }

        public string Address { get; set; }

        public int ItemId { get; set; }
  
    }
}