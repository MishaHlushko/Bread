using Microsoft.AspNetCore.Mvc.Rendering;
using Beads_Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beads_Store.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Beads_Store.Data.Interfaces
{
    public interface IBeadsService
    {
        Task<BeadsListViewModel> GetBeadsAsync();
        Task<BeadsViewModel> GetMIbyIdAsync(int miId);
        Task AddBeadsAsync(BeadsViewModel beadsViewModel, IFormFile uploadedImage);
        Task<BeadsViewModel> GetBeadsViewModelAsync();
        Task<BeadsViewModel> GetBeadsViewModelAsync(int id);
        Task DeleteBeadsAsync(int id);
        Task EditAsync(BeadsViewModel model, IFormFile uploadedImage);
        Task<BeadsListViewModel> SearchBeadsByStringAsync(string searchString);
        Task<BeadsListViewModel> FilterAndSearchByCategoryAsync(int? categoryId, string searchString);
    }
}
