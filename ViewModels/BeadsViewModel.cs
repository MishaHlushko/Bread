using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Beads_Store.Data.Models;

namespace Beads_Store.ViewModels
{
    public class BeadsViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { set; get; }

        [Required(ErrorMessage = "Поле Назва є обов'язкове.")]
        [Display(Name = "Назва")]
        public string nameMI { set; get; }

        [Required(ErrorMessage = "Поле Опис є обов'язкове.")]
        [Display(Name = "Опис")]
        public string descMI { set; get; }

        [Required(ErrorMessage = "Кількість є обов'язковою.")]
        [Display(Name = "Кількість")]
        public int quantity { set; get; }

        [Required(ErrorMessage = "Поле Ціна є обов'язкове.")]
        [Display(Name = "Ціна")]
        public ushort price { set; get; }

        [Required(ErrorMessage = "Зображення є обов'язкове.")]
        [Display(Name = "Зображення")]
        public string img { set; get; }

        public bool IsDeleted { set; get; }
        public bool available { set; get; }

        [Required(ErrorMessage = "Оберіть категорію")]
        [Display(Name = "Категорія")]
        public int categoryId { set; get; }
        public IEnumerable<SelectListItem> categories { get; set; }

        public BeadsViewModel() { }

        public BeadsViewModel(Beads beads)
        {
            Id = beads.Id;
            nameMI = beads.nameMI;
            descMI = beads.descMI;
            quantity = beads.quantity;
            price = beads.price;
            img = beads.img;
            IsDeleted = beads.IsDeleted;
            available = beads.available;
            categoryId = beads.MICategoryId;
        }

    }
}
