using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventSeed
    {
        public static async Task SeedAsync(EventContext context)
        {
            context.Database.Migrate();
            if (!context.EventTopics.Any())
            {
                context.EventTopics.AddRange
                    (GetPreConfiguredEventTopics());
                context.SaveChanges();
            }
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange
                    (GetPreConfiguredEventTypes());
                context.SaveChanges();
            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange
                    (GetPreConfiguredEventItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventTopic> GetPreConfiguredEventTopics()
        {
            return new List<EventTopic>()
            {
                new EventTopic{ Topic ="Auto,Boat& Air"},
                new EventTopic{ Topic ="Buisness & Professional"},
                new EventTopic{ Topic ="Charity & causes"},
                new EventTopic{ Topic ="Community & Culture"},
                new EventTopic{ Topic ="Family&Education"},
                new EventTopic{ Topic ="Fashion& Beauty"},
                new EventTopic{ Topic ="Film Media& Entertainment"},
                new EventTopic{ Topic ="Food & Drink"},
                new EventTopic{ Topic ="Government& politics"},
                new EventTopic{ Topic ="Health & Wellness"},
                new EventTopic{ Topic ="Hobbies & special Interest"}
            };
        }

        private static IEnumerable<EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>()
            {
                new EventType{ Type ="Appaearance or signing"},
                new EventType{ Type ="Attraction"},
                new EventType{ Type ="Camp,Trip or Retreat"},
                new EventType{ Type ="Class,training or Workshop"},
                new EventType{ Type ="Concert or Performance"},
                new EventType{ Type ="Conference"},
                new EventType{ Type ="Convention"},
                new EventType{ Type ="Dinner or Gala"},
                new EventType{ Type ="Festival or Fair"},
                new EventType{ Type ="Game or Competition"},
                new EventType{ Type ="Meeting or Networking"},
                new EventType{ Type ="Party or Social Gathering"},
                new EventType{ Type ="Race or endurance Event"},
                new EventType{ Type ="Rally"},
                new EventType{ Type ="Screening"},
                new EventType{ Type ="Seminar or Talk"},
                new EventType{ Type ="Tour"},
                new EventType{ Type ="Tournament"},
                new EventType{ Type ="Tradeshow,ConsumerShow or Expo"}
            };
        }

        private static IEnumerable<EventItem> GetPreConfiguredEventItems()
        {
            return new List<EventItem>()
            {

                new EventItem() { EventTypeId = 8,EventTopicId = 8, Description = "Join us for the annual Gilman Village Sip and Shop Wine Walk on the Saturday, No 17th. Live music, snacks and Washington boutique wines poured in various tasting locations at Gilman Village retail shops, Get an early start on your holiday shopping and enjoy specials at participating retail shops and restaurants.", Title = "Gilman Village Sip and Shop - wine tasting", Location = "Gilman Village,317 Northwest Gilman Boulevard,Issaquah, WA 98027",StartDate="Oct 10,2018",EndDate="Oct 10,2018",Price = 25.5M, ImageUrl = "http://externaleventbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventTypeId = 6,EventTopicId = 2, Description = "Interaction Week 2019 will assemble a diverse group of practitioners and academics from around the world to explore the edges of interaction design, and help spark a transformation of the discipline to be relevant to the needs of the 21st century. ", Title = "Interaction Week 2019", Location = "Seattle,Seattle, WA 98121",StartDate=" Feb 3, 2019",EndDate="Feb 8, 2019",Price = 95.5M, ImageUrl = "http://externaleventbaseurltobereplaced/api/pic/2" },
                new EventItem() { EventTypeId = 5,EventTopicId = 3, Description = "Join us for a memorable night of music making! Our fabulous AWSOM teachers will perform works their favorite composers, ending with a surprise performance! Admittance is free and open to the public, so please invite your friends and family! There will also be light refreshments available.", Title = "AWSOM Faculty Recital 2018", Location = "St Thomas Episcopal Church,8398 Northeast 12th Street,Medina, WA 98039",StartDate="October 20, 2018",EndDate="October 20, 2018",Price = 0.5M, ImageUrl = "http://externaleventbaseurltobereplaced/api/pic/3" },
                new EventItem() { EventTypeId = 5,EventTopicId = 4, Description = "The path between two musical eras: the Baroque and the Classical, with English composer William Boyce. Discover a dark world of trolls and giants against an austere Scandinavian landscape as Danish composer Carl Nielsen draws us into a psychological exploration of duality in his Clarinet Concerto with soloist Sean Osborn. Finally, sink into the depths of Brahms’s tender feelings for Clara Schumann, where he struggles between the forces of love and friendship in a warm and pensive piece. Experience these masterworks through the vibrant voice of Seattle's conductorless chamber orchestra.", Title = "Duality -NORTH CORNER CHAMBER ORCHESTRA", Location = "RESONANCE at SOMA Towers,288 106th Avenue Northeast,#203,Bellevue, WA 98004",StartDate=" October 27, 2018",EndDate=" October 27, 2018",Price = 30.5M, ImageUrl = "http://externaleventbaseurltobereplaced/api/pic/4" }
             };
        }
    }
}
