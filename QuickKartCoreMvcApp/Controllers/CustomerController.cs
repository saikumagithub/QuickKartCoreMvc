using Microsoft.AspNetCore.Mvc;

namespace QuickKartCoreMvcApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerHome()
        {
            List<string> lstProducts = new List<string>();
            lstProducts.Add("Dell Inspiron");
            lstProducts.Add("Marble chess board");
            lstProducts.Add("Adidas shoes");
            ViewBag.TopProducts = lstProducts;
            return View();
        }
    }
}
