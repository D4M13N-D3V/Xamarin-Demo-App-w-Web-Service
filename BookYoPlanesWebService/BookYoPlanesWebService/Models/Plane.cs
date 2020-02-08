using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookYoPlanesWebService.Models
{
    public class Plane
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

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}