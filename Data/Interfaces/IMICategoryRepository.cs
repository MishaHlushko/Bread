using Beads_Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beads_Store.Data.Interfaces
{
    public interface IMICategoryRepository
    {
        Task<IEnumerable<MICategory>> GetMICategories();
        Task<MICategory> GetMICategoryByIdAsync(int id);
        Task Create(string name);
        Task UpdateCategoryAsync(int Id, string nameMI);
        Task DeleteCategory(int id);
    }
}
