using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beads_Store.Data.Interfaces;
using Beads_Store.ViewModels;
using Beads_Store.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beads_Store.Controllers
{
    public class BeadsController : Controller
    {
        private readonly IBeadsService _beadsService;
        private readonly IMICategoryService _mICategoryService;

        public BeadsController(IBeadsService iBeadsService, IMICategoryService iMICategoryService)
        {
            _beadsService = iBeadsService;
            _mICategoryService = iMICategoryService;
        }


        public async Task<IActionResult> Index(int? categoryId, string searchString = null)
        {
            if (categoryId != null && categoryId != 0)
            {
                return View(await _beadsService.FilterAndSearchByCategoryAsync(categoryId, searchString));
            }
            
            else if (!string.IsNullOrEmpty(searchString))
            {
                return View(await _beadsService.SearchBeadsByStringAsync(searchString));
            }
            else
            {
              
                
                return View(await _beadsService.GetBeadsAsync());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(await _beadsService.GetBeadsViewModelAsync());
        }

        [HttpPost]

        public async Task<IActionResult> Create(BeadsViewModel model, IFormFile uploadedImage)
        {

            try
            {
                TempData["AlertMessage"] = "Товар успішно додано!";
                await _beadsService.AddBeadsAsync(model, uploadedImage);
                return RedirectToAction("Index", "Beads");
            }
            catch
            {
                TempData["AlertMessage"] = "При додаванні товару виникла помилка";
                return RedirectToAction("Create", "Beads");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int miId)
        {
            try
            {
                TempData["AlertMessage"] = "Товар успішно видалено!";
                await _beadsService.DeleteBeadsAsync(miId);
                return RedirectToAction("Index", "Вeads");
            }
            catch
            {
                return RedirectToAction("Index", "Beads");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _beadsService.GetBeadsViewModelAsync(id));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(BeadsViewModel model, IFormFile uploadedImage)
        {
            try
            {
                TempData["AlertMessage"] = "Товар успішно змінено!";
                await _beadsService.EditAsync(model, uploadedImage);
                return RedirectToAction("Index", "Вeads");
            }
            catch
            {
                return RedirectToAction("Index", "Вeads");
            }
            
        }
        
    }

}
