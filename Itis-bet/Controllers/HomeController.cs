using Microsoft.AspNetCore.Mvc;

namespace ITIS_Bet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Privacy() => View();     
        
    }
}
