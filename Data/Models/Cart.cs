
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Beads_Store.Data.Models
{
    public class Cart
    {    
        public string CartId { get; set; }
        public List<CartLine> cartLines { get; set; }

        
    }
}
