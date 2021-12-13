using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int beadsId { get; set; }
        public uint price { get; set; }
        public virtual Beads beads { get; set; }
        public virtual Order order { get; set; }
    }
}
