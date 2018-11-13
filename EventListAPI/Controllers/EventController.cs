using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventListAPI.Data;
using EventListAPI.Domain;
using EventListAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventListAPI.Controllers
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

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemByID(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var item = await _eventContext.EventItems.SingleOrDefaultAsync(c => c.Id == id);
            if (item != null)
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
        [Route("[action]/withlocation/{location:minlength(1)}")]
        public async Task<IActionResult> Items(string location, [FromQuery] int pageSize = 2, [FromQuery] int pageIndex = 0)
        {
            var totalItems = await _eventContext.EventItems
                .Where(c => c.Location.StartsWith(location))
                .LongCountAsync();
            var itemsOnPage = await _eventContext.EventItems
                .Where(c => c.Location.StartsWith(location))
                 .OrderBy(c => c.Title)
                 .Skip(pageIndex * pageSize)//skipping pages and data
                 .Take(pageSize)
                 .ToListAsync();
            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            var model = new PaginatedItemsViewModel<EventItem>(pageSize, pageIndex, totalItems, itemsOnPage);
            // return Ok(itemsOnPage);
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/type/{eventTypeId}/topic/{eventTopicId}")]
        public async Task<IActionResult> Items(int? eventTypeId, int? eventTopicId, [FromQuery] int pageSize = 2, [FromQuery] int pageIndex = 0)
        {
            var root = (IQueryable<EventItem>)_eventContext.EventItems;
            if (eventTypeId.HasValue)
            {
                root = root.Where(c => c.EventTypeId == eventTypeId);
            }
            if (eventTopicId.HasValue)
            {
                root = root.Where(c => c.EventTopicId == eventTopicId);
            }

            var totalItems = await root.LongCountAsync();
            var itemsOnPage = await root
                 .OrderBy(c => c.Title)
                 .Skip(pageIndex * pageSize)//skipping pages and data
                 .Take(pageSize)
                 .ToListAsync();
            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            var model = new PaginatedItemsViewModel<EventItem>(pageSize, pageIndex, totalItems, itemsOnPage);
            // return Ok(itemsOnPage);
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/startdate/{startDate}/endDate/{endDate}")]
        public async Task<IActionResult> Items(DateTime startDate, DateTime endDate, [FromQuery] int pageSize = 2, [FromQuery] int pageIndex = 0)
        {
            var root = (IQueryable<EventItem>)_eventContext.EventItems;
            if (startDate != null)
            {
                root = root.Where(c => c.StartDate.Date == startDate.Date);//Here .Date extracts data value from DateTime format
            }
            if (endDate != null)
            {
                root = root.Where(c => c.EndDate.Date == endDate.Date);
            }

            var totalItems = await root.LongCountAsync();
            var itemsOnPage = await root
                 .OrderBy(c => c.Title)
                 .Skip(pageIndex * pageSize)//skipping pages and data
                 .Take(pageSize)
                 .ToListAsync();
            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            var model = new PaginatedItemsViewModel<EventItem>(pageSize, pageIndex, totalItems, itemsOnPage);
            // return Ok(itemsOnPage);
            return Ok(model);
        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateEvent([FromBody]EventItem myevent)
        {
            var item = new EventItem
            {
                Title = myevent.Title,
                Location = myevent.Location,
                StartDate = myevent.StartDate,
                EndDate = myevent.EndDate,
                ImageUrl = myevent.ImageUrl,
                Description = myevent.Description,
                Organizer = myevent.Organizer,
                Price = myevent.Price,
                EventTopicId = myevent.EventTopicId,
                EventTypeId = myevent.EventTypeId
            };
            _eventContext.EventItems.Add(item);
            await _eventContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemByID), new { id = item.Id });
        }

        private List<EventItem> ChangeUrlPlaceholder(List<EventItem> items)
        {
            items.ForEach(x =>
            x.ImageUrl = x.ImageUrl.Replace("http://externaleventbaseurltobereplaced", _configuration["ExternalEventBaseUrl"]));
            return items;


        }
    }
}