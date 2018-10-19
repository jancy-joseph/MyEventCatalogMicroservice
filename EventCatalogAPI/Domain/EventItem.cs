using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
        public string Organizer { get; set; }
        public decimal Price { get; set; }
        //  public string Ticket { get; set; }
        // public string TicketName { get; set; }
        //public int TicketTotalQuantity{ get; set; }
        //public int TicketQuantityAvailable { get; set; }

        //public decimal TicketPrice { get; set; }

        //public string TicketCurrencyTibePaid { get; set; }
        //public string TicketCountryToBePaid { get; set; }
       // public int TicketTypeID { get; set; } 
        public int EventTypeId { get; set; }
        public int EventTopicId { get; set; }

        public virtual EventTopic EventTopic { get; set; }
        public virtual EventType EventType { get; set; }
      //  public virtual TicketType TicketType { get; set; }



    }
}
