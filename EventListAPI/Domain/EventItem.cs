using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventListAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }

        public string Description { get; set; }
        public string Organizer { get; set; }
        public decimal Price { get; set; }

        public int EventTypeId { get; set; }
        public int EventTopicId { get; set; }

        public virtual EventTopic EventTopic { get; set; }
        public virtual EventType EventType { get; set; }

        //public class TicketType
        //{
        //    public int ID { get; set; }
        //    public string Type { get; set; }
        //    free,Paid,Donation
        //}
        //public string Ticket { get; set; }
        //public string TicketName { get; set; }
        //public int TicketTotalQuantity { get; set; }
        //public int TicketQuantityAvailable { get; set; }

        //public decimal TicketPrice { get; set; }

        //public string TicketCurrencyTibePaid { get; set; }
        //public string TicketCountryToBePaid { get; set; }
        //public int TicketTypeID { get; set; }

        //public virtual TicketType TicketType { get; set; }

    }
}
