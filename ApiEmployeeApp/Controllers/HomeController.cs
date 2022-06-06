using ApiEmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ApiEmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseUrl = "http://dummy.restapiexample.com/api/v1/";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employeeData = new List<Employee>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("employees");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    var serialize = JsonConvert.DeserializeObject<Employees>(EmpResponse);
                    employeeData = serialize.EmployeesList;

                    //employeeData = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);

                    //return View(employeeData);
                }
                return View(employeeData);
            }
        }


        public async Task<IActionResult> EmployeeDetail(int employeeId)
        {
            var employeeData = new Employee();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("employee/" + employeeId);

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    var serialize = JsonConvert.DeserializeObject<SingleEmployee>(EmpResponse);
                    employeeData = serialize.myEmployee;

                    //employeeData = JsonConvert.DeserializeObject<Employee>(EmpResponse);
                }
                return View(employeeData);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}