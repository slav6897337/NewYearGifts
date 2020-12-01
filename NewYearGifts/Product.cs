using System;
using System.Collections.Generic;
using System.Text;

namespace NewYearGifts
{
    class Product
    {
        public int id { get; set; }

        public string key { get; set; }

        public string name { get; set; }

        public string full_name { get; set; }

        public string name_prefix { get; set; }

        public string extended_name { get; set; }

        public string status { get; set; }

        public string header { get; set; }

        public string icon { get; set; }

        public string html_url { get; set; }

        public ProductPrices prices { get; set; }

        public string post_url { get; set; }

        public string url { get; set; }


    }
}
