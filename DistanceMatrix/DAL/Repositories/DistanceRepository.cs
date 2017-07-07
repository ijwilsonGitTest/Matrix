using DistanceMatrix.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DistanceMatrix.DAL.Repositories
{
    public class DistanceRepository
    {
        private string baseurl = "https://maps.googleapis.com/maps/api/distancematrix/json?";
        private string key = "AIzaSyDeYXutpFUZil3ILjdmM6Szqq6amOmL8MM";
        private List<Distance> History = new List<Distance>();

        public async Task<Distance> GetDistance(string origin, string destination, string mode = "")
        {
            string resultstring = null;
            Distance _distance = null;

            using (HttpClient c = new HttpClient())
            {
                HttpResponseMessage result = await c.GetAsync(baseurl + "origins=" + origin + "&destinations=" + destination + "&mode=" + mode + "&key=" + key);
                if (result.IsSuccessStatusCode)
                    resultstring = await result.Content.ReadAsStringAsync();
            }
            if (!String.IsNullOrEmpty(resultstring))
            {
                JToken distanceToken = JObject.Parse(resultstring);

                _distance = new Distance
                {
                    Destination = destination,
                    Origin = origin,
                    DistanceInMiles = distanceToken.SelectToken("rows[0].elements[0].distance.text").ToString(),
                    Duration = distanceToken.SelectToken("rows[0].elements[0].duration.text").ToString()
                };
            }
            return _distance;
        }

        public List<Distance> GetHistory()
        {
            return History;
        }

        public List<Distance> AddToHistory(Distance savedDistance)
        {
            History.Add(savedDistance);
            return History;
        }
    }
}