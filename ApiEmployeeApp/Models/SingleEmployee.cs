using Newtonsoft.Json;

namespace ApiEmployeeApp.Models
{
    public class SingleEmployee
    {
        [JsonProperty("data")]
        public Employee myEmployee { get; set; }
    }
}
