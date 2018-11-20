using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;
using static WebMvc.Infrastructure.ApiPaths;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private ICatalogService _catalogSvc;

        public CatalogController(ICatalogService catalogSvc) =>
            _catalogSvc = catalogSvc;

        public async Task<IActionResult> Index(
            int? CategoryFilterApplied,
            int? TypesFilterApplied,
            int? LocationFilterApplied,
            int? page)
        {

            int itemsPage = 10;
            var catalog = await
                _catalogSvc.GetCatalogItems
                (page ?? 0, itemsPage, CategoryFilterApplied,
                TypesFilterApplied, LocationFilterApplied);
            var vm = new CatalogIndexViewModel()
            {
                CatalogItems = catalog.Data,
                Categories = await _catalogSvc.GetEventCategories(),
                Types = await _catalogSvc.GetEventTypes(),
                Locations = await _catalogSvc.GetEventLocations(),
                CategoryFilterApplied = CategoryFilterApplied ?? 0,
                TypesFilterApplied = TypesFilterApplied ?? 0,
                LocationFilterApplied = LocationFilterApplied ?? 0,
                PaginationInfo = new PaginationInfo()
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsPage, //catalog.Data.Count,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling(((decimal)catalog.Count / itemsPage))
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }

    }
}