using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Domain
{
    public class CatalogEventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Schedule { get; set; }
        public string PictureUrl { get; set; }

        //adding Foriegn Keys
        public int CatalogCategoryId { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogLocationId { get; set; }

        //creating relationship
        public virtual CatalogEventCategory CatalogEventCategory { get; set; }
        public virtual CatalogEventType CatalogEventType { get; set; }
        public virtual CatalogEventLocation CatalogEventLocation { get; set; }

         
    }
}
