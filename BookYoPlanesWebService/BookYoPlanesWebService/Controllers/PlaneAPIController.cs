using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BookYoPlanesWebService.Models;
using Newtonsoft.Json;

namespace BookYoPlanesWebService.Controllers
{

    public class ApiPlane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int Luggage { get; set; }
        public int GolfSets { get; set; }
        public int SkiSets { get; set; }
        public string Description { get; set; }
        public bool Pets { get; set; }
        public bool Wifi { get; set; }
        public string ImageFile { get; set; }
    }

    public class ApiBooking
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int PlaneId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public ApiPlane Plane { get; set; }
    }

    [RoutePrefix("api")]
    public class PlaneAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("Planes/Details")]
        public IHttpActionResult GetPlainDetailsJson(int id)
        {
            var efPlane = db.Planes.FirstOrDefault(x => x.Id == id);
            var apiPlane = new ApiPlane()
            {
                Id = efPlane.Id,
                Name = efPlane.Name,
                Seats = efPlane.Seats,
                Luggage = efPlane.Luggage,
                GolfSets = efPlane.GolfSets,
                SkiSets = efPlane.SkiSets,
                Description = efPlane.Description,
                Wifi = efPlane.Wifi,
                Pets = efPlane.Pets,
                ImageFile = efPlane.ImageFile
            };
            return Json(apiPlane, new JsonSerializerSettings { Formatting = Formatting.Indented }); 
        }

        [Route("Planes")]
        public IHttpActionResult GetAllPlanesJson()
        {
            var efPlanes = db.Planes.ToList();
            List<ApiPlane> apiPlanes = new List<ApiPlane>();
            foreach(var efPlane in efPlanes)
            {
                var apiPlane = new ApiPlane()
                {
                    Id = efPlane.Id,
                    Name = efPlane.Name,
                    Seats = efPlane.Seats,
                    Luggage = efPlane.Luggage,
                    GolfSets = efPlane.GolfSets,
                    SkiSets = efPlane.SkiSets,
                    Description = efPlane.Description,
                    Wifi = efPlane.Wifi,
                    Pets = efPlane.Pets,
                    ImageFile = efPlane.ImageFile
                };
                apiPlanes.Add(apiPlane);
            }
            return Json(apiPlanes, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [HttpPost, Route("Bookings/Add")]
        public IHttpActionResult AddBooking(int planeId, string bookerId, DateTime startDate, DateTime endDate)
        {
            var newBooking = new Booking()
            {
                User = bookerId,
                Start = startDate,
                End = endDate,
                PlaneId = planeId
            };
            var savedBooking = db.Bookings.Add(newBooking);
            db.SaveChanges();
            var efPlane = db.Planes.FirstOrDefault(x => x.Id == savedBooking.PlaneId);
            var apiPlane = new ApiPlane()
            {
                Id = efPlane.Id,
                Name = efPlane.Name,
                Seats = efPlane.Seats,
                Luggage = efPlane.Luggage,
                GolfSets = efPlane.GolfSets,
                SkiSets = efPlane.SkiSets,
                Description = efPlane.Description,
                Wifi = efPlane.Wifi,
                Pets = efPlane.Pets,
                ImageFile = efPlane.ImageFile
            };
            var apiBooking = new ApiBooking()
            {
                Id = savedBooking.Id,
                User = savedBooking.User,
                Start = savedBooking.Start,
                End = savedBooking.End,
                PlaneId = savedBooking.PlaneId,
                Plane = apiPlane
            };
            return Json(apiBooking, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }


        [Route("Booking/ForUser")]
        public IHttpActionResult GetBookingDetailsJson(string bookerId)
        {
            var efBookings = db.Bookings.Where(x => x.User == bookerId).ToList();
            List<ApiBooking> apiBookings = new List<ApiBooking>();
            foreach(var efBooking in efBookings)
            {
                var apiPlane = new ApiPlane()
                {
                    Id = efBooking.Plane.Id,
                    Name = efBooking.Plane.Name,
                    Seats = efBooking.Plane.Seats,
                    Luggage = efBooking.Plane.Luggage,
                    GolfSets = efBooking.Plane.GolfSets,
                    SkiSets = efBooking.Plane.SkiSets,
                    Description = efBooking.Plane.Description,
                    Wifi = efBooking.Plane.Wifi,
                    Pets = efBooking.Plane.Pets,
                    ImageFile = efBooking.Plane.ImageFile
                };
                var apiBooking = new ApiBooking()
                {
                    Id = efBooking.Id,
                    User = efBooking.User,
                    Start = efBooking.Start,
                    End = efBooking.End,
                    PlaneId = efBooking.PlaneId,
                    Plane = apiPlane
                };
                apiBookings.Add(apiBooking);
            }
            return Json(apiBookings, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}