using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogItems(int page, int take, int? category, int? type, int? location);
        Task<IEnumerable<SelectListItem>> GetEventCategories();
        Task<IEnumerable<SelectListItem>> GetEventTypes();
        Task<IEnumerable<SelectListItem>> GetEventLocations();
    }
}