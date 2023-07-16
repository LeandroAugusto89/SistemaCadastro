using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using System.Diagnostics;

namespace SistemaCadastro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HomeModel home = new HomeModel();
            home.Nome = "Leandro Augusto";
            home.Email = "leandroaugusto89@yahoo.com.br";
            return View(home);
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