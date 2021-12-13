using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Beads_Store.Data.Interfaces;
using Beads_Store.Data.Models;
using Beads_Store.ViewModels;

namespace Beads_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly IBeadsService _beadsService;
        private readonly ICartService _cartService;
        private Cart _cart;
        public CartController(IBeadsService beadsService, ICartService cartService, Cart cart)
        {
            _beadsService = beadsService;
            _cartService = cartService;
            _cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            
            var elements = await _cartService.GetCartLines(_cart);
            _cart.cartLines = elements;

            var obj = new CartViewModel { cartViewModel = _cart };

            return View(obj);
        }

        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await _beadsService.GetMIbyIdAsync(id);
            if (item != null)
            {
                TempData["AlertMessage"] = "Успішно додано!";
                await _cartService.AddToCartAsync(item, _cart);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCartLine(int cartlineId)
        {
            try
            {
                TempData["AlertMessage"] = "Успішно видалено!";
                await _cartService.DeleteCartLineAsync(cartlineId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
