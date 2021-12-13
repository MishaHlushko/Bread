using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beads_Store.Data.Models;

namespace Beads_Store.Data.Interfaces
{
    public interface IBeadsRepository
    {
        Task<IEnumerable<Beads>> GetBeads();
        Task<Beads> GetMIbyIdAsync(int miId);
        Task<IEnumerable<SelectListItem>> GetCategoriesForDropdownAsync();
        Task AddBeadsAsync(Beads beads);
        Task DeleteBeadsAsync(Beads beads);
        Task EditAsync(Beads beads);
        Task<List<Beads>> SearchBeadsByStringAsync(string searchString);
        Task<List<Beads>> FilterAndSearchByCategoryAsync(int? categoryId, string searchString);
        Task<IEnumerable<SelectListItem>> GetCategoriesForDropdownForFilterAsync();
    }
}
