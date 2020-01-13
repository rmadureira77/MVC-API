using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_DAL;
using _02_WebService.Models.Repositorio;

namespace _02_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IDataRepositorio<Produto> _dataRepositorio;

        public ProdutosController(IDataRepositorio<Produto> dataRepositorio)
        {
            _dataRepositorio = dataRepositorio;
        }

        // GET: api/Produtos
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Produto> produtos = _dataRepositorio.GetAll();
            return Ok(produtos);
        }

        // GET: api/Empregados/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Produto produto = _dataRepositorio.Get(id);

            if (produto == null)
            {
                return NotFound("Empregado inexistente.");
            }

            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto inexistente.");
            }

            Produto produtoToUpdate = _dataRepositorio.Get(id);
            if (produtoToUpdate == null)
            {
                return NotFound("O produto não foi encontrado.");
            }

            _dataRepositorio.Update(produtoToUpdate, produto);
            return NoContent();
        }

        // POST: api/Produtos
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("O produto não existe.");
            }

            _dataRepositorio.Add(produto);
            return CreatedAtRoute(
                  "Get",
                  new { Id = produto.Id },
                  produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Produto produto = _dataRepositorio.Get(id);
            if (produto == null)
            {
                return NotFound("O produto não foi encontrado.");
            }

            _dataRepositorio.Delete(produto);
            return NoContent();
        }

        
    }
}
