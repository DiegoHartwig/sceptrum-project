using Microsoft.AspNetCore.Mvc;
using SceptrumProject.Application.DTO;
using SceptrumProject.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SceptrumProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> BuscarCategorias()
        {
            var categorias = await _categoriaService.BuscarCategoriasAsync();

            if(categorias == null)
            {
                return NotFound("Categorias não encontradas");
            }
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "BuscarCategoria")]
        public async Task<ActionResult<CategoriaDTO>> BuscarCategoriaPeloId(int id)
        {
            var categoria = await _categoriaService.BuscarPeloIdAsync(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest("Dados inválidos");

            await _categoriaService.CriarAsync(categoriaDto);

            return new CreatedAtRouteResult("BuscarCategoria", new { id = categoriaDto.Id }, categoriaDto);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest();

            if (id != categoriaDto.Id)
                return BadRequest();

            await _categoriaService.AtualizarAsync(categoriaDto);

            return Ok(categoriaDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Deletar(int id)
        {
            var categoria = await _categoriaService.BuscarPeloIdAsync(id);
            if(categoria == null)
            {
                return NotFound("Categoria não localizada.");
            }

            await _categoriaService.RemoverAsync(id);
            return Ok(categoria);
        }
    }
}
