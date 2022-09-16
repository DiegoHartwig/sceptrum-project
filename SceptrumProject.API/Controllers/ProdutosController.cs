using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SceptrumProject.Application.DTO;
using SceptrumProject.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SceptrumProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> BuscarProdutos()
        {
            var produtos = await _produtoService.BuscarProdutosAsync();

            if (produtos == null)
            {
                return NotFound("Produtos não encontrados");
            }
            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "BuscarProduto")]
        public async Task<ActionResult<ProdutoDTO>> BuscarProdutoPeloId(int id)
        {
            var produto = await _produtoService.BuscarPeloIdAsync(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Dados inválidos");

            await _produtoService.CriarAsync(produtoDto);

            return new CreatedAtRouteResult("BuscarProduto", new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest();

            if (id != produtoDto.Id)
                return BadRequest();

            await _produtoService.AtualizarAsync(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Deletar(int id)
        {
            var produto = await _produtoService.BuscarPeloIdAsync(id);
            if (produto == null)
            {
                return NotFound("Categoria não localizada.");
            }

            await _produtoService.RemoverAsync(id);
            return Ok(produto);
        }
    }
}
