using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class HotelFind
    {
        public List<result> results { set; get; }
        public string status { get; set; }
    }
}