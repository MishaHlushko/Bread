using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beads_Store.Data.Interfaces;
using Beads_Store.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beads_Store.Data.Repository
{
    public class BeadsRepository : IBeadsRepository
    {
        private readonly AppDBContext _appDBContext;
        public BeadsRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<IEnumerable<Beads>> GetBeads()
        {
            return await _appDBContext.Beads.ToListAsync();
        }

        public async Task<Beads> GetMIbyIdAsync(int miId)
        {
            return await _appDBContext.Beads.FirstOrDefaultAsync(Beads => Beads.Id == miId);
        }

        public async Task AddBeadsAsync(Beads beads)
        {
            await _appDBContext.Beads.AddAsync(beads);
            _appDBContext.SaveChanges();
        }

        public async Task DeleteBeadsAsync(Beads beads)
        {
            _appDBContext.Beads.FirstOrDefault(p => p.Id == beads.Id).IsDeleted = true;
            await _appDBContext.SaveChangesAsync();

        }

        public async Task EditAsync(Beads beads)
        {
            _appDBContext.ChangeTracker.Clear();

            _appDBContext.Beads.Update(beads);
            await _appDBContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<SelectListItem>> GetCategoriesForDropdownAsync()
        {
            List<SelectListItem> categories = await _appDBContext.mICategories.Select(n =>
            new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.categoryName
            }).ToListAsync();

            return new SelectList(categories, "Value", "Text");
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesForDropdownForFilterAsync()
        {
            List<SelectListItem> categories = await _appDBContext.mICategories.Select(n =>
            new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.categoryName
            }).ToListAsync();

            SelectListItem selectListItem = new SelectListItem { Value = "0", Text = "All" };
            categories.Add(selectListItem);


            return new SelectList(categories, "Value", "Text");
        }
        public async Task<List<Beads>> SearchBeadsByStringAsync(string searchString)
        {
            return await _appDBContext.Beads.Where(m => m.nameMI.Contains(searchString)).ToListAsync();
        }

        public async Task<List<Beads>> FilterAndSearchByCategoryAsync(int? categoryId, string searchString)
        {
            IQueryable<Beads> beads = _appDBContext.Beads.Include(m => m.MICategory).Where(m => m.MICategoryId == categoryId);

            if (!string.IsNullOrEmpty(searchString))
            {
                beads = beads.Where(m => m.nameMI.Contains(searchString));
            }


            return await beads.ToListAsync();

        }
    }
}
