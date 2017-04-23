using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutprice
{
    public class ItemPriceJson
    {//test
        [JsonProperty("prices")]
        public price price { get; set; } 
    }

    public class price
    {
        [JsonProperty("name")]
        public string name { get; set;}

        [JsonProperty("unit_price")]
        public int unit_price { get; set; }

        [JsonProperty("special_price")]
        public int special_price { get; set; }

        [JsonProperty("special_quantity")]
        public int special_quantity { get; set; }
    }

    
  }
