using CategoriasMVC.Models;
using CategoriasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoriasMVC.Controllers;
public class CategoriasController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    public async Task<ActionResult<IEnumerable<CategoriaViewModel>>> Index()
    {
        var result = await _categoriaService.GetCategorias();
        if(result==null)
        {
            return View("Error");
        }
        return View(result);
    }

    [HttpGet]
    public IActionResult CriarNovaCategoria()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaViewModel>> CriarNovaCategoria(CategoriaViewModel categoriaVM)
    {
        if(ModelState.IsValid)
        {
            var result = await _categoriaService.CriaCategoria(categoriaVM);

            if(result != null)
                return RedirectToAction(nameof(Index));
        }
        ViewBag.Error = "Erro ao criar Categoria";
        return View(categoriaVM);
    }

    [HttpGet]
    public async Task<IActionResult> AtualizarCategoria(int id)
    {
        var result = await _categoriaService.GetCategoriaPorId(id);

        if(result is null)
            return View("Error");

        return View(result);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaViewModel>> AtualizarCategoria(int id, CategoriaViewModel categoriaVM)
    {
        if(ModelState.IsValid)
        {
            var result = await _categoriaService.AtualizaCategoria(id, categoriaVM);
            if(result)
                return RedirectToAction(nameof(Index));
        }
        ViewBag.Error="Erro ao atualizar Categoria";
        return View(categoriaVM);
    }

    [HttpGet]
    public async Task<IActionResult> DeletarCategoria(int id)
    {
        var result = await _categoriaService.GetCategoriaPorId(id);

        if (result is null)
            return View("Error");

        return View(result);
    }
    [HttpPost(), ActionName("DeletarCategoria")]
    public async Task<IActionResult> DeletaConfirmado(int id)
    {
        var result = await _categoriaService.DeleteCategoria(id);
        if(result)
            return RedirectToAction("Index");

        return View("Error");
    }

}