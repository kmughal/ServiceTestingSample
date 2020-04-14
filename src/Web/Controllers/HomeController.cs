namespace Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.IO;


    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Image { get; set; }
        public string Age { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult GetFakeJson()
        {
            var mockPath = Path.Combine("mock", "fake.json");
            var contents = System.IO.File.ReadAllText(mockPath);
            var result = (List<Employee>)System.Text.Json.JsonSerializer.Deserialize(contents, typeof(List<Employee>));
            return Json(result);
        }

        [HttpPost]
        public IActionResult PostFakeData(Employee e)
        {
            e.Name = "khurram";
            return Json(e);
        }
    }
}
