using Business.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Diagnostics;
using WEB.Models;

namespace WEB.Controllers
{
    public class UsuarioController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.usuarios = Usuario.Busca();
            return View();
        }
        
    }
}
