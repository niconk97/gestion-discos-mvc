using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Discos.Web.Models;
using Discos.Negocio;

namespace Discos.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ListadoDiscos()
    {
        IAccesoDatos accesoDatos = new AccesoDatosSQLITE();
        DiscoNegocio negocio = new DiscoNegocio(accesoDatos);
        var discos = negocio.listar();
        return View(discos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
