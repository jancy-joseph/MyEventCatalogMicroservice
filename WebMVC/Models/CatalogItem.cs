using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class CatalogItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime Schedule { get; set; }
        public int CatalogCategoryId { get; set; }
        public string CatalogEventCategory { get; set; }
        public int CatalogTypeId { get; set; }
        public string CatalogEventType { get; set; }
        public int CatalogLocationId { get; set; }
        public string CatalogEventLocation { get; set; }
    }
}