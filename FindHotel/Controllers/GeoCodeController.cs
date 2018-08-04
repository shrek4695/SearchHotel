using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoogleMaps.LocationServices;
using FindHotel.Models;

namespace FindHotel.Controllers
{
    public class GeoCodeController : ApiController
    {
        [HttpGet]
        public void GeoCodeFinder(String Address)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(Address);
            LatLong codeObject = new LatLong();
            codeObject.latitude = point.Latitude;
            codeObject.longitude = point.Longitude;

        }
    }
}
