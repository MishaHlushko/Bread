using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.Data.Models
{
    public class MICategory
    {
        public int Id { set; get; }
        public string categoryName { set; get; }
        public bool isDeleted { get; set; }
        public List<Beads> beads  { set; get; }
    }
}
