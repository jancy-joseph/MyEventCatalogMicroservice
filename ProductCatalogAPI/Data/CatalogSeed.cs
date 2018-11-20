using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.CatalogEventCategories.Any())
            {
                context.CatalogEventCategories.AddRange(GetPreConfiguredCatalogEventCategories());
                context.SaveChanges();
            }
            if (!context.CatalogEventTypes.Any())
            {
                context.CatalogEventTypes.AddRange(GetPreConfiguredCatalogEventTypes());
                context.SaveChanges();
            }
            if (!context.CatalogEventLocations.Any())
            {
                context.CatalogEventLocations.AddRange(GetPreConfiguredCatalogEventLocations());
                context.SaveChanges();
            }
            if (!context.CatalogEventItems.Any())
            {
                context.CatalogEventItems.AddRange(GetPreConfiguredCatalogEventItems());
                context.SaveChanges();
            }
        }
        private static IEnumerable<CatalogEventCategory> GetPreConfiguredCatalogEventCategories()
        {
            return new List<CatalogEventCategory>()
            {
                new CatalogEventCategory { Category="Arts"},
                new CatalogEventCategory { Category="Buisiness & Career"},
                new CatalogEventCategory { Category="Community"},
                new CatalogEventCategory { Category="Entertainment"},
                new CatalogEventCategory { Category="Food & Drink"},
                new CatalogEventCategory { Category="Kids"},
                new CatalogEventCategory { Category="Sports & Fitness"},
                new CatalogEventCategory { Category="Outdoor"},
                new CatalogEventCategory { Category="OtherCategories"},
            };

        }
        private static IEnumerable<CatalogEventType> GetPreConfiguredCatalogEventTypes()
        {
            return new List<CatalogEventType>()
            {
                new CatalogEventType { Type="Attraction"},
                new CatalogEventType { Type="Class"},
                new CatalogEventType { Type="Concert"},
                new CatalogEventType { Type="CareerFair"},
                new CatalogEventType { Type="Competetion"},
                new CatalogEventType { Type="Conference"},
                new CatalogEventType { Type="Festivals"},
                new CatalogEventType { Type="Game"},
                new CatalogEventType { Type="OtherTypes"},
                new CatalogEventType { Type="Party"},
                new CatalogEventType { Type="Screening"},
                new CatalogEventType { Type="Tournment"},

            };

        }
        private static IEnumerable<CatalogEventLocation> GetPreConfiguredCatalogEventLocations()
        {
            return new List<CatalogEventLocation>()
            {
                new CatalogEventLocation { Location="Bellevue"},
                new CatalogEventLocation { Location="Redmond"},
                new CatalogEventLocation { Location="Renton"},
                new CatalogEventLocation { Location="Seattle"},
                new CatalogEventLocation { Location="Sammamish"},
                new CatalogEventLocation { Location="Lynnwood"},
                new CatalogEventLocation { Location="Kirkland"},
                new CatalogEventLocation { Location="Issaquah"},
                new CatalogEventLocation { Location="Anacortes"},
                new CatalogEventLocation { Location="Everett"},

            };


        }

        private static IEnumerable<CatalogEventItem> GetPreConfiguredCatalogEventItems()
        {
            return new List<CatalogEventItem>()
            {

                new CatalogEventItem() {CatalogCategoryId=1,CatalogTypeId=1,CatalogLocationId=2,Name="Morbid Anatomy Art Show at Ballyhoo",Description="Join Seattle artist Anita Arora at Ballyhoo Curiosity Shop in Ballard, Seattle for this one night Reception of her unique shadowbox artwork. Anita will be on hand to discuss the magic that goes on in making these exquisite curisoity pieces that hark back to a time long gone. Antique poison bottles, pages from anatomy textbooks, dried roses, bone and a slew of oddities that provide symbolism wrapped up in a Victorian charm. Contemplate them up close and take home your favorite. Wine will be available for guests 21+. Can't make the Reception? The show will be on display at Ballyhoo Curiosity Shop.",Schedule=DateTime.Parse("10/18/2018 8:30:00 AM"),Price =0.00M,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/1"},

                new CatalogEventItem() {CatalogCategoryId=1,CatalogTypeId=2,CatalogLocationId=1,Name="sketch comedy writing through improvisation with joe guppy",Description="learn to write comedy with fun and energizing improv games, as taught by emmy-award-winning comedy writer, joe guppy. students will learn basic improv skills, and how to build a comedy premise. we will gather around a supportive and encouraging writer’s table to rewrite using story structure, and study scenes from saturday night live, key & peele, and comedy films. perfect for aspiring or experienced improvisers, actors, comedy writers, screenwriters, playwrights. the class culminates with a writers’ showcase at unexpected productions' market theater (performance optional).",Schedule=DateTime.Parse("12/11/2018 4:30:00 pm"),Price=20.32m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/2"} ,

                new CatalogEventItem() {CatalogCategoryId=1,CatalogTypeId=7,CatalogLocationId=3,Name="enta omri 2018 seattle summer flower oriental dance festival",Description="on october 7th 2018, seattle summer flower oriental dance festival will host a special oriental dance festival in the women's university club from 3pm to 5pm. you will experience an unprecedented dance style that is a mix of chinese folklore and modern dance.guo wei: the king of chinese belly dancing will join us. he was the first person in china to bring belly dancing into the market, and taught belly dancing since 2004 with more than 200,000 students in china and overseas.summer wang: one of the few dancers who specializes in dancing a variety of styles, especially the fusion of chinese style",Schedule=DateTime.Parse("12/12/2018 10:30:00 am"),Price=30.43m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/3"} ,

                new CatalogEventItem() {CatalogCategoryId=2,CatalogTypeId=2,CatalogLocationId=4,Name="2018 annual lunch & learn - hot topics for hr & business professionals",Description="this year's hot topics in hr features high-value presentations. scroll down for full descriptions.can you train your way to workforce equity?, an expert panel discussion regarding effective workforce training to promote diversity, inclusion, and cultural compentcy and achieve workforce equity.washington’s paid family and medical leave program: getting employers ready for 2019, presented by esdand a dynamic keynote that has received rave reviews to end our day - flip the script: four habits to radically increase productivity and potential ",Schedule=DateTime.Parse("01/01/2019 8:30:52 am"),Price=19.23m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/4"} ,

                new CatalogEventItem() { CatalogCategoryId = 2, CatalogTypeId = 4, CatalogLocationId = 4, Name = "seattle career fair - october 16, 2018 - live recruiting/hiring event", Description = "live recruiting/hiring event! ready for a new career?  national career fairs is the industry leader and we are driving employers and future employees together faster then ever before.", Schedule =DateTime.Parse("08/1/2019 6:30:00 pm"), Price = 0.00m, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },

                new CatalogEventItem() { CatalogCategoryId = 3, CatalogTypeId = 7, CatalogLocationId = 6, Name = "crowfest 2018",Description = "details: annual meeting of the wuuu:crowfest 2018 : citizen researchers of wuuu prepare yourself.a body washes up on woodmont beach in 1933, setting in motion a national scandal. murders? suicides? accidents? all were on the table in 1933.at an undisclosed and supremely comfortable location in des moines (you’ll be provided instructions upon your rsvp), join the wuuu for the telling of the incredible, tragic, and unbelievably true tale with so many loose ends it remains wholly unraveled, 85 years later.",Schedule =DateTime.Parse("8/12/2018 8:30:00 am"),Price = 0.00m,PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },

                new CatalogEventItem() { CatalogCategoryId = 3, CatalogTypeId = 10, CatalogLocationId = 10, Name = "small biz popup market at alderwood", Description = "join us as reactivate teams up with popupsters, kiva.org and ggp inc at alderwood for our montlhy small biz popup markets. the small biz popup markets will activate the alderwood on the third weekend of every month bringing you the best local businesses for you to discover.", Schedule =DateTime.Parse("08/02/2019 6:30:00 pm"), Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },

                new CatalogEventItem() { CatalogCategoryId = 3, CatalogTypeId = 2, CatalogLocationId = 8, Name = "filipino christmas lantern workshop", Description = "learn about parols (filipino christmas lanterns) and how to make them. parols are popular christmas decorations that often resemble stars. in this workshop, we will take a modern approach to a traditional parol, using cardstock, and led lights. these parols can be hung up to brighten your house for the holidays. make one with your family! addition filipino christmas lanterns kits are $15 and can be bought at the event. ticket price include (1) lantern kit & refreshments provided by musang seattle & outside the box. one free admission for a child (ages 6-17) with (1) paying adult. this project is reccomended for ages 6 and up.space is limited.",Schedule=DateTime.Parse("01/1/2019 3:30:00 pm"),Price=25.80m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/8"},

                new CatalogEventItem() { CatalogCategoryId = 4, CatalogTypeId = 11, CatalogLocationId = 3, Name = "fall's french cinema - un conte de noël", Description = "discover the new wave of francophone directors this fall with the alliance française de seattle's cultural program. this fall's french cinema program is the neo nouvelle - vague, in reference to the generation of filmmakers that made the french new wave in the 50s and 60s (godard, truffaut, rohmer, etc.), breaking traditional narrative codes and innovating with plots, genres, and editing techniques.", Schedule =DateTime.Parse("02/1/2019 3:30:00 pm"), Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new CatalogEventItem() { CatalogCategoryId = 5, CatalogTypeId = 1, CatalogLocationId = 7, Name = "christmas ship festival dinner cruise", Description = "join tinte cellars | william church & cuillin hills wineries for a private holiday party during the christmas ship festival on lake washington! board our private vessel at kirkland’s carillon point, and delight in the shimmering views of a holiday-lit winter sky as we follow the lead boat.enjoy a delicious holiday dinner * * two glasses of william church / cuillin hills wine per person, and spectacular views of the official christmas ship, as well as choir performances broadcast from the lead boat at each community stop.",Schedule=DateTime.Parse("02/1/2019 6:30:00 pm"),Price=100,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new CatalogEventItem() { CatalogCategoryId = 6, CatalogTypeId = 2, CatalogLocationId = 7, Name = "kid's painting lessons", Description = "we created a special series of four kid's painting lessons with a syllabus for learning! or, join us for just one day to try it out.", Schedule =DateTime.Parse("01/12/2019 6:30:00 pm"), Price = 28.75m, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new CatalogEventItem() { CatalogCategoryId = 7, CatalogTypeId = 2, CatalogLocationId = 5, Name = "growing yoga teachers: yama sequence fall 2018 / winter 2019", Description = "growing yoga teachers is a program designed especially to help find answers to these questions and more. designed around the needs of recent yoga teacher training program graduates who are finding their voice and want more connection and feedback. the yama sequence is a series of 5 monthly 4 hour workshops covering issues that come up in class, enhancing your teaching, and business issues that come up as a yoga teacher. each month these small group workshops will provide community and support to yoga teachers. material covered will be a honing and deepening of the subjects you were introduced to during your 200hr yoga teacher training in order to help you discover what kind of a teacher you want to be.", Schedule =DateTime.Parse("01/1/2019 05:30:00 am"), Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },

                new CatalogEventItem() { CatalogCategoryId = 7, CatalogTypeId = 12, CatalogLocationId = 4, Name = "war at the winds",Description="arlingon kickboxing academy(aka) is proud to present to you war at the winds, the next wave of standup fighting to hit the puget sound area.join us for a live full contact kickboxing event at angel of the winds casino",Schedule=DateTime.Parse("12/12/2018 5:00:00 pm"),Price=65.83m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/13"},
                new CatalogEventItem() { CatalogCategoryId = 8,CatalogTypeId = 1,CatalogLocationId = 3,Name = "fall fun activities at the farm at swan's trail",Description = "set along the beautiful snohomish river just outside of seattle, the farm at swan's trail is home to authentic fall fun for everyone. enjoy our enormous 50-acre pumpkin patch, the washington state corn maze, the petting farm, wagon rides, u-pick apple orchard, live duck races, and farmer ben's famous four little pigs show.",Schedule =DateTime.Parse("01/2/2019 6:30:00 pm"),Price = 10,PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new CatalogEventItem() { CatalogCategoryId = 9,CatalogTypeId = 2,CatalogLocationId = 10,Name = "seattle, wa - iata/imo seminar",Description = "iata training seminar shipping dangerous goods by air",Schedule=DateTime.Parse("1/1/2019 6:30:00 pm"),Price=0.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/15"},
                new CatalogEventItem() { CatalogCategoryId = 1, CatalogTypeId = 3, CatalogLocationId = 6, Name = "plu sounds of christmas", Description = "sounds of christmas, featuring the university singers and men's chorus, directed by dr. richard nance and barry johnson", Schedule =DateTime.Parse("12/3/2019 6:30:00 pm"), Price = 34.65m, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16" },
                new CatalogEventItem() { CatalogCategoryId = 7, CatalogTypeId = 5, CatalogLocationId = 6, Name = "2019 speedo sectionals at federal way, wa", Description = "this link is to reserve spots for athletes to swim in federal way that are in the four corners region. athletes in region xii do not need to reserve spots", Schedule =DateTime.Parse("02/1/2019 6:30:00 pm"), Price = 13, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17" }

            };
        }
    }
}
