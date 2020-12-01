using System;
using System.Collections.Generic;
using System.Text;

namespace NewYearGifts
{
    class Product
    {
        public string full_name { get; set; }

        public string name_prefix { get; set; }

        public string extended_name { get; set; }

        public ProductPrices prices { get; set; }

    }
}
