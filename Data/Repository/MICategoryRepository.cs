using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beads_Store.Data.Interfaces;
using Beads_Store.Data.Models;


namespace Beads_Store.Data.Repository
{

    public class MICategoryRepository : IMICategoryRepository
    {
        private readonly AppDBContext appDBContext;
        public MICategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<IEnumerable<MICategory>> GetMICategories()
        {
           return await appDBContext.mICategories.ToListAsync();
        }

        public async Task<MICategory> GetMICategoryByIdAsync(int id)
        {
            return await appDBContext.mICategories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(string name)
        {
            await appDBContext.mICategories.AddAsync(new MICategory { categoryName = name, isDeleted = false });
            appDBContext.SaveChanges();
        }

        public async Task UpdateCategoryAsync(int Id, string nameMI)
        {
            var category = await GetMICategoryByIdAsync(Id);
            category.categoryName = nameMI;
            appDBContext.SaveChanges();
        }

        public async Task DeleteCategory(int id)
        {
            MICategory mICategory = await GetMICategoryByIdAsync(id);
            IEnumerable<Beads> beads = await appDBContext.Beads.Where(m => m.MICategoryId == id).ToListAsync();

            foreach(Beads m in beads)
            {
                m.IsDeleted = true;
            }

            mICategory.isDeleted = true;
            appDBContext.SaveChanges();
        }
    }

}
