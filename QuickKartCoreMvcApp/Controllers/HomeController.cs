using Microsoft.AspNetCore.Mvc;
using QuickKartCoreMvcApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using QuickKartDataAccessLayer.Models;
using QuickKartDataAccessLayer;


namespace QuickKartCoreMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuickKartContext _context;
        QuickKartRepository repObj;

        public HomeController(ILogger<HomeController> logger, QuickKartContext context)
        {
            _logger = logger;
            _context = context;
            repObj = new QuickKartRepository(_context);
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CheckRole(IFormCollection frm)
        {
            string userId = frm["name"];
            string password = frm["pwd"];
            //when checkbox is checked in html forms it will be set to on
            string checkbox = frm["RememberMe"];
            if(checkbox == "on")
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("UserId",userId,option);
                Response.Cookies.Append("Password",password,option);
            }
            // this is for query string
            //splitting the useremailid into strings and get first elemnt in array string
            string username = userId.Split('@')[0];
            byte? roleId = repObj.ValidateCredentials(userId, password);
            if (roleId == 1)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("AdminHome", "Admin");
                //FIRST PARAMETER IS VIEW NAME AND SECOND PARAMETER IS CONTROLLER 
            }
            else if (roleId == 2)
            {
                //return RedirectToAction("CustomerHome", "Customer");
                // modifying for the query string
                return Redirect("/Customer/CustomerHome?username=" +username);
            }
            return View("Login");
        }

        public JsonResult GetCupons()
           
        {
            Random random = new Random();
            Dictionary<string,string > data = new Dictionary<string,string>();
            //keys values
            string[] key = { "Arts", "Electronics", "Fashion", "Home", "Toys" };
            string[] value = new string[5];
            //generating values by random class
            for(int i = 0; i <5; i++)
            {
                string number = "RUSH" +random.Next(1,10).ToString()
                    + random.Next(1, 10).ToString()+ random.Next(1, 10).ToString();

                value[i] = number;

            }
            //adding key and value to the data
            for(int i = 0;i < 5; i++)
            {
                data.Add(key[i], value[i]);
            }
            return Json(data);

        }

        public ViewResult Contact() { 
            return View();
        
        }
        
        public RedirectResult FAQ()
        {
            return Redirect("/Home/Contact");
            //here before /home it is base url
            //total url is baseurl+/Home/Contact
        }


        //Exercise question for actions
        public ContentResult EmployeeInfo()
        {
            // Create XML data for employee details
            string xmlData = "<EmployeeDetails>";

            // Add employee details (replace this with actual data)
            xmlData += "<Employee><Name>John Doe</Name><Position>Software Developer</Position></Employee>";
            xmlData += "<Employee><Name>Jane Smith</Name><Position>Project Manager</Position></Employee>";

            xmlData += "</EmployeeDetails>";

            // Return ContentResult with XML data
            return Content(xmlData, "application/xml");
        }


    }
}
