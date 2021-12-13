using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.Data.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public Beads beads { get; set; }
        public int price { get; set; }
        public string CartId { get; set; }
    }
}
