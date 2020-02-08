using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookYoPlanesWebService.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int PlaneId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual Plane Plane { get; set; }
    }
}