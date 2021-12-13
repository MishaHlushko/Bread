using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beads_Store.Data.Interfaces;
using Beads_Store.Data.Models;
using Beads_Store.ViewModels;

namespace Beads_Store.Data.Services
{
    public class BeadsService : IBeadsService
    {
        private readonly IBeadsRepository _beadsRepository;
        private readonly IMICategoryRepository _mICategoryRepository;
        private readonly IWebHostEnvironment _appEnvironment;
        public BeadsService(IBeadsRepository beadsRepository, IWebHostEnvironment appEnvironment, IMICategoryRepository mICategoryRepository)
        {
            _mICategoryRepository = mICategoryRepository;
            _beadsRepository = beadsRepository;
            _appEnvironment = appEnvironment;
        }

       
        public async Task<BeadsListViewModel> GetBeadsAsync()
        {
            return new BeadsListViewModel { ListBeads = await _beadsRepository.GetBeads(), categories = (SelectList)await _beadsRepository.GetCategoriesForDropdownForFilterAsync() }; 
        }


        public async Task<BeadsViewModel> GetMIbyIdAsync(int miId)
        {
            Beads beads = await _beadsRepository.GetMIbyIdAsync(miId);
            if (beads != null)
            {
                return new BeadsViewModel(beads);
            }

            return null;
        }
       
        public async Task AddBeadsAsync(BeadsViewModel beadsViewModel, IFormFile uploadedImage)
        {

            if(uploadedImage != null)
            {
                
                string path = "/img/" + uploadedImage.FileName;
                
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedImage.CopyToAsync(fileStream);
                }
                var beads = new Beads()
                {
                    nameMI = beadsViewModel.nameMI,
                    descMI = beadsViewModel.descMI,
                    quantity = beadsViewModel.quantity,
                    price =beadsViewModel.price,
                    img = path,
                    available = beadsViewModel.available,
                    IsDeleted = false,
                    MICategoryId = beadsViewModel.categoryId

                };
                await _beadsRepository.AddBeadsAsync(beads);
            }

            
        }

        public async Task DeleteBeadsAsync(int id)
        {
            Beads beads = await _beadsRepository.GetMIbyIdAsync(id);


            if (beads != null)
            {
                await _beadsRepository.DeleteBeadsAsync(beads);
            }

        }

        public async Task EditAsync(BeadsViewModel model, IFormFile uploadedImage)
        {

            Beads beads = new Beads
            {
                Id = model.Id,
                nameMI = model.nameMI,
                descMI = model.descMI,
                price = model.price,
                available = model.available,
                IsDeleted = model.IsDeleted,
                quantity = model.quantity,
                MICategoryId = model.categoryId
            };
            if (uploadedImage != null)
            {
                string path = _appEnvironment.WebRootPath + _beadsRepository.GetMIbyIdAsync(model.Id).Result.img;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                path = "/img/" + uploadedImage.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedImage.CopyToAsync(fileStream);
                }

                beads.img = path;
                
            }
            else
            {
                
                beads.img = _beadsRepository.GetMIbyIdAsync(model.Id).Result.img;
            }
            await _beadsRepository.EditAsync(beads);
        }

        public async Task<BeadsViewModel> GetBeadsViewModelAsync()
        {
            var beadsViewModel = new BeadsViewModel
            {
                categories = await _beadsRepository.GetCategoriesForDropdownAsync()
            };

            return beadsViewModel;
        }

        public async Task<BeadsViewModel> GetBeadsViewModelAsync(int id)
        {
            var beads = await _beadsRepository.GetMIbyIdAsync(id);
            var beadsViewModel = new BeadsViewModel
            {
                Id = id,
                nameMI = beads.nameMI,
                descMI = beads.descMI,
                price = beads.price,
                available = beads.available,
                img = beads.img,
                IsDeleted = beads.IsDeleted,
                quantity = beads.quantity,
                categoryId = beads.MICategoryId,
                categories = await _beadsRepository.GetCategoriesForDropdownAsync()
            };

            return beadsViewModel;
        }

        public async Task<BeadsListViewModel> SearchBeadsByStringAsync(string searchString)
        {
            var beadsListViewModel = new BeadsListViewModel
            {
                ListBeads = await _beadsRepository.SearchBeadsByStringAsync(searchString),
                categories = (SelectList)await _beadsRepository.GetCategoriesForDropdownForFilterAsync()
            };


            return beadsListViewModel;
        }

        public async Task<BeadsListViewModel> FilterAndSearchByCategoryAsync(int? categoryId, string searchString)
        {

            BeadsListViewModel beadsListViewModel = new BeadsListViewModel
            {
                ListBeads = await _beadsRepository.FilterAndSearchByCategoryAsync(categoryId, searchString),
                categories = (SelectList)await _beadsRepository.GetCategoriesForDropdownForFilterAsync()
            };

            return beadsListViewModel;
        }

    }
}
