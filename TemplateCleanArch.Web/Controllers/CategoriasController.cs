using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateCleanArch.Application.Interfaces;

namespace TemplateCleanArch.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.BuscarCategoriasAsync();
            return View(categorias);
        }
    }
}
