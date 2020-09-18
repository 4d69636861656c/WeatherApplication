using Newtonsoft.Json;

namespace WeatherApplication.Models
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double ThreeHour { get; set; }
    }

}