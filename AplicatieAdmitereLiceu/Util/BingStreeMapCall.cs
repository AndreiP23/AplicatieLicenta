using GMap.NET;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Util
{
    public class BingStreeMapCall
    {
        public async Task<PointLatLng?> GetLocationAsync(string address)
        {
            var httpClient = new HttpClient();
            string requestUri = $"http://dev.virtualearth.net/REST/v1/Locations?q={Uri.EscapeDataString(address)}&key=AgyN8KY2NwXGnYuxqesWrrWBrmeD462ziyjzOgtMyQG5b4oT8xjO2d7b_9uUsBWn";

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(jsonResult);

                var location = jsonResponse["resourceSets"][0]["resources"][0]["point"]["coordinates"];
                double lat = (double)location[0];
                double lng = (double)location[1];

                return new PointLatLng(lat, lng);
            }

            return null;
        }
    }
}
