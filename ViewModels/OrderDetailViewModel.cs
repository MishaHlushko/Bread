using Microsoft.AspNetCore.Mvc;
using Beads_Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.ViewModels
{
    public class OrderDetailViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { set; get; }

        public List<Beads> beadsViewModels { get; set; }
        public string nameMI { get; set; }
        public uint price { get; set; }
        public DateTime orderTime { get; set; }
        public OrderStatusViewModel orderStatusViewModel { get; set; }

    }
}
