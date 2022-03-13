using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TSD.Linq.Task1.Lib.Model
{
    public class GoldPrice
    {
        [JsonProperty("Data")]
        public DateTime Date { get; set; }

        [JsonProperty("Cena")]
        public double Price { get; set; }
    }
}
