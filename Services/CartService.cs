using Beads_Store.Data.Interfaces;
using Beads_Store.Data.Models;
using Beads_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.Data.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task AddToCartAsync(BeadsViewModel beads, Cart cart)
        {
            await _cartRepository.AddToCartAsync(beads, cart);
        }

        public Task DeleteCartLineAsync(int id)
        {
            return _cartRepository.DeleteCartLineAsync(id);
        }

        public async Task<List<CartLine>> GetCartLines(Cart cart)
        {
           return await Task.Run(() => _cartRepository.GetCartLines(cart));
        }
    }
}
