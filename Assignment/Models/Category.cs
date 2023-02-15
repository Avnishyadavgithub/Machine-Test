using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Category
    {
        public int Category_id {get;set;}
        public string Category_name { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
       
    }

    public class Product
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
    }
}