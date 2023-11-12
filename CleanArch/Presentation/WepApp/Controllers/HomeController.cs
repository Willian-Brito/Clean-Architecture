using Microsoft.AspNetCore.Mvc;
using WepApp.Models;

namespace WepApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View("Privacy");
    }
}
