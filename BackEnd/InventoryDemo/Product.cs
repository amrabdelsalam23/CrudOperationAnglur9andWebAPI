using System;
using System.Collections.Generic;

namespace DALInvemtory.Models
{
    public partial class Product
    {
        public int Productid { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<System.DateTime> lastupdated { get; set; }
    }
}
