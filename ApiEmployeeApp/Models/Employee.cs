using Newtonsoft.Json;

namespace ApiEmployeeApp.Models
{

    public class Employee
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("employee_name")]
        public string? EmployeeName { get; set; }
        [JsonProperty("employee_salary")]
        public int EmployeeSalary { get; set; }
        [JsonProperty("employee_age")]
        public int EmployeeAge { get; set; }
        [JsonProperty("profile_image")]
        public string? ProfileImage { get; set; }
    }
}
