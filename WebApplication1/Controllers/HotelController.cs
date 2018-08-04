using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using GoogleMaps.LocationServices;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HotelController : ApiController
    {
        
        //public int Radius { get; set; }
        //public var GeocodeLat { get; set; }
        //public var GeocodeLong { get; set; }

        [HttpGet]
        //[Route("api/Hotel")]
        public List<result> GeoCodeGetter([FromUri]String Address)
        {
            
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(Address);
            var GeocodeLat = point.Latitude;
            var GeocodeLong = point.Longitude;

            using (var client = new WebClient())
            {


                string uri = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=hotels&key=AIzaSyAVLsqceM992z4csR8oZJMkDjlcUzK7a0I&location="+GeocodeLat+","+GeocodeLong+"&radius=10";
                String json = client.DownloadString(uri).ToString();
                var dict = JsonConvert.DeserializeObject<HotelFind>(json);
                return dict.results;
            }
        }
    }
}
