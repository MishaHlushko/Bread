using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beads_Store.Data.Models;
namespace Beads_Store.ViewModels
{
    public class BeadsListViewModel
    {
        public IEnumerable<Beads> ListBeads { get; set; }
        public int categoryId { set; get; }
        public SelectList categories { get; set; }
    }
}
