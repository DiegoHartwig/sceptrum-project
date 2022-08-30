using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;
using SceptrumProject.Application.DTO;
using SceptrumProject.Application.Interfaces;

namespace SceptrumProject.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _environment;

        public ProdutosController(IProdutoService produtoService, ICategoriaService categoriaService, IWebHostEnvironment environment)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
            _environment = environment;
        }   

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.BuscarProdutosAsync();
            return View(produtos);
        }

        [HttpGet()]
        public async Task<IActionResult> Inserir()
        {
            ViewBag.CategoriaId = new SelectList(await _categoriaService.BuscarCategoriasAsync(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(ProdutoDTO produtoDto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.CriarAsync(produtoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(produtoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar (int? id)
        {
            if (id == null) return NotFound();
            var produtoDto = await _produtoService.BuscarPeloIdAsync(id);

            if (produtoDto == null) return NotFound();

            var categorias = await _categoriaService.BuscarCategoriasAsync();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descricao", produtoDto.CategoriaId);

            return View(produtoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produtoDto)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.AtualizarAsync(produtoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(produtoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null) return NotFound();

            var produtoDto = await _produtoService.BuscarPeloIdAsync(id);

            if (produtoDto == null) return NotFound();

            return View(produtoDto);
        }

        [HttpPost(), ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDeletar(int id)
        {
            await _produtoService.RemoverAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null) return NotFound();
            var produtoDto = await _produtoService.BuscarPeloIdAsync(id);

            if (produtoDto == null) return NotFound();

            var wwwroot = _environment.WebRootPath;
            var imagem = Path.Combine(wwwroot, "imagens\\" + produtoDto.Imagem);
            var exists = System.IO.File.Exists(imagem);
            ViewBag.ImagemExistente = exists;

            return View(produtoDto);
        }
    }
}
