using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public CatalogService(IOptionsSnapshot<AppSettings> settings,
            IHttpClient httpClient)
        {
            _settings = settings;
            _apiClient = httpClient;
            _remoteServiceBaseUrl = $"{_settings.Value.CatalogUrl}/api/catalog/";

        }

        public async Task<IEnumerable<SelectListItem>> GetEventCategories()
        {
            var getEventsUri = ApiPaths.Catalog.GetAllEventCategories(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getEventsUri);
            
            var categories = JArray.Parse(dataString);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };

            foreach (var category in categories.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = category.Value<string>("id"),
                    Text = category.Value<string>("category")
                });
            }

            return items;
        }

        public async Task<Catalog> GetCatalogItems(int page, int take, int? category, int? type, int? location)
        {
            var allcatalogItemsUri = ApiPaths.Catalog.GetAllCatalogItems(_remoteServiceBaseUrl, page, take, category, type, location);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<Catalog>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetEventTypes()
        {
            var getTypesUri = ApiPaths.Catalog.GetAllEventTypes(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getTypesUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = type.Value<string>("id"),
                    Text = type.Value<string>("type")
                });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetEventLocations()
        {
            var getLocationsUri = ApiPaths.Catalog.GetAllEventLocations(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getLocationsUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var locations = JArray.Parse(dataString);
            foreach (var location in locations.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = location.Value<string>("id"),
                    Text = location.Value<string>("location")
                });
            }
            return items;
        }

       
    }
}