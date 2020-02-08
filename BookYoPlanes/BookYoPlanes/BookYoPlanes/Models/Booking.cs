using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookYoPlanes.Models
{
    public class Booking
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("User")]
        public string User { get; set; }
        [JsonProperty("PlaneId")]
        public int PlaneId { get; set; }
        [JsonProperty("Start")]
        public DateTime Start {get;set;}
        public string StartText
        {
            get
            {
                return Start.ToString("MM/dd/yyyy");
            }
        }
        [JsonProperty("End")]
        public DateTime End { get; set; }
        public string EndText
        {
            get
            {
                return End.ToString("MM/dd/yyyy");
            }
        }
        [JsonProperty("Plane")]
        public Plane Plane { get; set; }
    }
}
