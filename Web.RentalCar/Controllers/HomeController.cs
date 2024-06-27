using Infrastructure.RentalCar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Web.RentalCar.Models;

namespace Web.RentalCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {


            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyJSON()

        {
            return Json(new
            {
                id = 1,
                name = "Jill Chiu",
                age = 18
            }) ;
        }
        public IActionResult MyXML()

        {
            return Content(@"
                <xml>
                    <id>1</id>
                    <name>Jill</name>
                    <age>18</age>
                </xml>",
                "application/xml",
                Encoding.UTF8);
        }
        public IActionResult DownloadFile()

        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Download", "Test.xlsx");
            //return Content (path,"text/txt",Encoding.UTF8);
            var stream = System.IO.File.OpenRead(path);
            return File(stream, "application/xlsx", "公司教育訓練清冊.xlsx");
        }
        public IActionResult MyPartial()
            
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
