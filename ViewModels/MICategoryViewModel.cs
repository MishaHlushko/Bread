using Beads_Store.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.ViewModels
{
    public class MICategoryViewModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Поле Назва є обов'язкове.")]
        [Display(Name = "Назва")]
        public string categoryName { set; get; }
        public List<Beads> beads
        { set; get; }

        public MICategoryViewModel() { }

        public MICategoryViewModel(MICategory mICategory)
        {
            Id = mICategory.Id;
            categoryName = mICategory.categoryName;
        }
    }
}
