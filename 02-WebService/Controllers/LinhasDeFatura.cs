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
    public class LinhasDeFaturaController : ControllerBase
    {
        private readonly IDataRepositorio<LinhaDeFatura> _dataRepositorio;

        public LinhasDeFaturaController(IDataRepositorio<LinhaDeFatura> dataRepositorio)
        {
            _dataRepositorio = dataRepositorio;
        }

        // GET: api/LinhasDeFatura
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LinhaDeFatura> linhasdefatura = _dataRepositorio.GetAll();
            return Ok(linhasdefatura);
        }

        // GET: api/LinhasDeFatura/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            LinhaDeFatura linhasdefatura = _dataRepositorio.Get(id);

            if (linhasdefatura == null)
            {
                return NotFound("Linha de fatura inexistente.");
            }

            return Ok(linhasdefatura);
        }

        // PUT: api/LinhasDeFatura/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LinhaDeFatura linhadefatura)
        {
            if (linhadefatura == null)
            {
                return BadRequest("Linha de fatura inexistente.");
            }

            LinhaDeFatura linhaToUpdate = _dataRepositorio.Get(id);
            if (linhaToUpdate == null)
            {
                return NotFound("Linha de fatura inexistente.");
            }

            _dataRepositorio.Update(linhaToUpdate, linhadefatura);
            return NoContent();
        }

        // POST: api/LinhaDeFatura
        [HttpPost]
        public IActionResult Post([FromBody] LinhaDeFatura linhadefatura)
        {
            if (linhadefatura == null)
            {
                return BadRequest("Linha de fatura não existe.");
            }

            _dataRepositorio.Add(linhadefatura);
            return CreatedAtRoute(
                  "Get",
                  new { Id = linhadefatura.Id },
                  linhadefatura);
        }

        // DELETE: api/LinhaDeFatura/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            LinhaDeFatura linhadefatura = _dataRepositorio.Get(id);
            if (linhadefatura == null)
            {
                return NotFound("A linha de faturao não foi encontrada.");
            }

            _dataRepositorio.Delete(linhadefatura);
            return NoContent();
        }

        
    }
}
