using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateCleanArch.Application.Interfaces;

namespace TemplateCleanArch.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }   

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.BuscarProdutosAsync();
            return View(produtos);
        }
    }
}
