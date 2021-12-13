using Beads_Store.Data.Models;
using Beads_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.Data.Interfaces
{
    public interface ICartService
    {
        public Task AddToCartAsync(BeadsViewModel beads, Cart cart);
        public Task<List<CartLine>> GetCartLines(Cart cart);
        public Task DeleteCartLineAsync(int id);
    }
}
