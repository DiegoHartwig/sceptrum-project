using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TemplateCleanArch.Application.DTO;
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

        [HttpGet]
        public async Task<IActionResult> Inserir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(CategoriaDTO categoriaDto)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.CriarAsync(categoriaDto);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var categoriaDto= await _categoriaService.BuscarPeloIdAsync(id);

            if (categoriaDto == null) return NotFound();

            return View(categoriaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaDTO categoriaDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaService.AtualizarAsync(categoriaDto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null) return NotFound();

            var categoriaDto = await _categoriaService.BuscarPeloIdAsync(id);

            if (categoriaDto == null) return NotFound();

            return View(categoriaDto);
        }

        [HttpPost(), ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDeletar(int id)
        {
            await _categoriaService.RemoverAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var categoriaDto = await _categoriaService.BuscarPeloIdAsync(id);

            if (categoriaDto == null) return NotFound();

            return View(categoriaDto);
        }
    }
}
