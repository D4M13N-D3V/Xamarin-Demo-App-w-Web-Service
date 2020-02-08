using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BookYoPlanes.Models
{
    public class Plane
    {
            [JsonProperty("Id")]
            public int Id { get; set; }
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Seats")]
            public int Seats { get; set; }
            [JsonProperty("Luggage")]
            public int Luggage { get; set; }
            [JsonProperty("GolfSets")]
            public int GolfSets { get; set; }
            [JsonProperty("SkiSets")]
            public int SkiSets { get; set; }
            [JsonProperty("Description")]
            public string Description { get; set; }
            [JsonProperty("Pets")]
            public bool Pets { get; set; }
            [JsonProperty("Wifi")]
            public bool Wifi { get; set; }
            [JsonProperty("ImageFile")]
            public string ImageFile { get; set; }
            
        public override string ToString()
        {
            return Name;
        }
    }
}
