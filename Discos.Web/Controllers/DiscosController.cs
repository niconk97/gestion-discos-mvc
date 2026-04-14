using Microsoft.AspNetCore.Mvc;
using Discos.Negocio;
using Discos.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Discos.Web.Controllers;

public class DiscosController : Controller
{
    private readonly DiscoNegocio discoNegocio;
    private readonly EstiloNegocio estiloNegocio;
    private readonly TipoEdicionNegocio tipoEdicionNegocio;

    public DiscosController(
        DiscoNegocio discoNegocio,
        EstiloNegocio estiloNegocio,
        TipoEdicionNegocio tipoEdicionNegocio)
    {
        this.discoNegocio = discoNegocio;
        this.estiloNegocio = estiloNegocio;
        this.tipoEdicionNegocio = tipoEdicionNegocio;
    }

    // GET: Discos
    public IActionResult Index()
    {
        List<Disco> discos = discoNegocio.listar();
        return View(discos);
    }

    // GET: Discos/Details/5
    public IActionResult Details(int id)
    {
        // TODO: Cargar el disco por id y devolver la vista de detalle
        return View();
    }

    // GET: Discos/Create
    public IActionResult Create()
    {
        ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
        ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");
        return View();
    }

    // POST: Discos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Disco nuevoDisco)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return View(nuevoDisco); // si hubo algun error de validacion, se vuelve a mostrar el formulario con los datos ingresados
            }
            discoNegocio.agregar(nuevoDisco);
            return RedirectToAction(nameof(Index));
        }
        catch
        {   
            return View(nuevoDisco);
        }
    }

    // GET: Discos/Edit/5
    public IActionResult Edit(int id)
    {
        // TODO: Cargar el disco a editar y combos necesarios
        return View();
    }

    // POST: Discos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, IFormCollection collection)
    {
        // TODO: Recibir cambios del formulario y actualizar el disco
        return RedirectToAction(nameof(Index));
    }

    // GET: Discos/Delete/5
    public IActionResult Delete(int id)
    {
        // TODO: Cargar el disco a eliminar y devolver la vista de confirmacion
        return View();
    }

    // POST: Discos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        // TODO: Eliminar el disco por id
        return RedirectToAction(nameof(Index));
    }
}