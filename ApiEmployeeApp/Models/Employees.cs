using Newtonsoft.Json;

namespace ApiEmployeeApp.Models
{
    public class Employees
    {
        [JsonProperty("data")]
        public List<Employee>? EmployeesList { get; set; }
    }
}
