using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beads_Store.Data.Models;

namespace Beads_Store.ViewModels
{
    public class OrderListViewModel
    { 
       
        public List<Order> orders { get; set; }
        public int statusOrderId { set; get; }
        public IEnumerable<SelectListItem> statusOrders { get; set; }
    }
}
