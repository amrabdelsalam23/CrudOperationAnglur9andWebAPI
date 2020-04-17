using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProductViewModel
    {
        public int Productid { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<System.DateTime> lastupdated { get; set; }
    }
}