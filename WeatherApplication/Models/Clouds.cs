using Newtonsoft.Json;

namespace WeatherApplication.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

}