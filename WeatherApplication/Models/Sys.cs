using Newtonsoft.Json;

namespace WeatherApplication.Models
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

}