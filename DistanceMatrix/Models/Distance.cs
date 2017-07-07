using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceMatrix.Models
{
    public class Distance
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Mode { get; set; }
        public string DistanceInMiles { get; set; }
        public string Duration { get; set; }
    }
}