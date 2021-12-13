using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beads_Store.Data.Models;
using Beads_Store.ViewModels;

namespace Beads_Store.Data.Interfaces
{
    public interface ICartRepository
    {
        
        public Task AddToCartAsync(BeadsViewModel beadsViewModel, Cart cart);
        public Task<List<CartLine>> GetCartLines(Cart cart);
        public Task DeleteCartLineAsync(int id);
    }
}
