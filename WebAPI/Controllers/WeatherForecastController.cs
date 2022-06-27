using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {


        public List<Employee> employeeList = new List<Employee>()
        {
             new Employee()
               {
                   EmpId =100, EmpName="Manoj", EmpAddress ="Banglore",EmpAge=25
               },
             new Employee()
               {
                   EmpId =101,  EmpName="Yash" ,EmpAddress="Delhi",EmpAge=32
               },
             new Employee()
               {
                   EmpId=103,  EmpName="Ram",EmpAddress="Hyderabad",EmpAge=23
               },
             new Employee()
               {
                   EmpId =106, EmpName="Parnitha" ,EmpAddress="Banglore",EmpAge=27
               },
        };
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // [HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //}
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(employeeList);

        }

        private string SayHi(string name)
        {
            return $"Hi {name}";

        }
        [HttpGet]
        public ActionResult GetName()
        {
            return Ok(SayHi("Sruthi"));
        }

        [HttpPost]
        public ActionResult Post()
        {
            employeeList.Add(new Employee { EmpId = 32, EmpName = "Manasa", EmpAddress = "Hyderabad", EmpAge = 35 });
            return Ok(employeeList);
        }



        [HttpGet]
        public ActionResult GetEmployeeDetails()
        {
            employeeList = new List<Employee>();
            employeeList.Add(new Employee { EmpId = 34, EmpName = "Ravali", EmpAddress = "Banglore", EmpAge = 25 });
            employeeList.Add(new Employee { EmpId = 37, EmpName = "Tanusri", EmpAddress = "Chennai", EmpAge = 27 });
            employeeList.Add(new Employee { EmpId = 39, EmpName = "Ram", EmpAddress = "Hyderabad", EmpAge = 23 });

            return Ok(employeeList);

        }

        [HttpPut]
        public ActionResult Update(int id)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            emp.EmpId = 23;
            emp.EmpName = "Manisha";
            emp.EmpAddress = "Delhi";
            emp.EmpAge = 22;
            return Ok(employeeList);
        }
        [HttpPatch]
        public ActionResult UpdatePartially(int id)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            emp.EmpId = 20;
            return Ok(employeeList);

        }

            [HttpDelete]
            public ActionResult Delete(int id)
            {


                var emp=employeeList.Where(x => x.EmpId == id).FirstOrDefault();
                employeeList.Remove(emp);


                return Ok(employeeList);
            }
        

    } 
}