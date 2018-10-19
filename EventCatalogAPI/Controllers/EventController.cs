using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    //[Route("api/[controller]")]
    //Added below two lines and commeneted the one above
    [Produces("application/json")]
    [Route("api/Event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _eventContext;
        private readonly IConfiguration _configuration;
        public EventController(EventContext eventContext, IConfiguration configuration)
        {
            _eventContext = eventContext;
            _configuration = configuration;

        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> EventTypes()
        {
            var items = await _eventContext.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> EventTopics()
        {
            var items = await _eventContext.EventTopics.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery] int pageSize = 2, [FromQuery] int pageIndex = 0)
        {
            var totalItems = await _eventContext.EventItems.LongCountAsync();
            var itemsOnPage = await _eventContext.EventItems
                 .OrderBy(c => c.Title)
                 .Skip(pageIndex * pageSize)//skipping pages and data
                 .Take(pageSize)
                 .ToListAsync();
            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            var model = new PaginatedItemsViewModel<EventItem>(pageSize, pageIndex, totalItems, itemsOnPage);
            // return Ok(itemsOnPage);
            return Ok(model);
        }
        ,
        [HttpGet]
        [Route("items/{id:int}")]      
        public async Task<IActionResult> GetItemByID(int id)
        {
            if(id <0)
            {
                return BadRequest();
            }
            var item =  await _eventContext.EventItems.SingleOrDefaultAsync(c => c.Id == id);
            if(item != null)
            {
                // COnverting single item to List so that we can re-use ChangeUrlPlaceholder function
                List<EventItem> eventList = new List<EventItem>();
                eventList.Add(item);
                eventList = ChangeUrlPlaceholder(eventList);
                item = eventList.SingleOrDefault(x => x.Id == id);
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/withtitle/{title:minlength(1)}")]
        public async Task<IActionResult> Items(string title, [FromQuery] int pageSize = 2, [FromQuery] int pageIndex = 0)
        {
            var totalItems = await _eventContext.EventItems
                .Where(c => c.Title.StartsWith(title))
                .LongCountAsync();
            var itemsOnPage = await _eventContext.EventItems
                .Where(c => c.Title.StartsWith(title))
                 .OrderBy(c => c.Title)
                 .Skip(pageIndex * pageSize)//skipping pages and data
                 .Take(pageSize)
                 .ToListAsync();
            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            var model = new PaginatedItemsViewModel<EventItem>(pageSize, pageIndex, totalItems, itemsOnPage);
            // return Ok(itemsOnPage);
            return Ok(model);
        }
        

        private List<EventItem> ChangeUrlPlaceholder(List<EventItem> items)
        {
            items.ForEach(x =>
            x.ImageUrl = x.ImageUrl.Replace("http://externaleventbaseurltobereplaced",_configuration["ExternalEventBaseUrl"]));
            return items;


        }
    }
}