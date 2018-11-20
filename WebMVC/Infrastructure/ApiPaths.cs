using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
        public static class Catalog
        {
            public static string GetAllCatalogItems(string baseUri,
                int page, int take, int? category, int? type, int? location)
            {
                var filterQs = string.Empty;

                if (category.HasValue || type.HasValue || location.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var locationQs =(location.HasValue) ? location.Value.ToString(): "null";
                    filterQs = $"location/{locationQs}/type/{typeQs}/category/{categoryQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetCatalogItem(string baseUri, int id)
            {

                return $"{baseUri}/items/{id}";
            }
            public static string GetAllEventCategories(string baseUri)
            {
                return $"{baseUri}catalogEventCategories";
            }

            public static string GetAllEventTypes(string baseUri)
            {
                return $"{baseUri}catalogEventTypes";
            }
            public static string GetAllEventLocations(string baseUri)
            {
                return $"{baseUri}catalogEventLocations";
            }
        }
        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }

    }
}