using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DAL;
using _02_WebService.Models.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturasController : ControllerBase
    {
        private readonly IDataRepositorio<Fatura> _dataRepositorio;

        public FaturasController(IDataRepositorio<Fatura> dataRepositorio)
        {
            _dataRepositorio = dataRepositorio;
        }

        // GET: api/Faturas
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Fatura> faturas = _dataRepositorio.GetAll();
            return Ok(faturas);
        }

        // GET: api/Faturas/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Fatura fatura = _dataRepositorio.Get(id);

            if (fatura == null)
            {
                return NotFound("Fatura inexistente.");
            }

            return Ok(fatura);
        }

        // PUT: api/Faturas/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fatura fatura)
        {
            if (fatura == null)
            {
                return BadRequest("Fatura inexistente.");
            }

            Fatura faturaToUpdate = _dataRepositorio.Get(id);
            if (faturaToUpdate == null)
            {
                return NotFound("A fatura é inexistente.");
            }

            _dataRepositorio.Update(faturaToUpdate, fatura);
            return NoContent();
        }

        // POST: api/Faturas
        [HttpPost]
        public IActionResult Post([FromBody] Fatura fatura)
        {
            if (fatura == null)
            {
                return BadRequest("A fatura nao existe.");
            }

            _dataRepositorio.Add(fatura);
            return CreatedAtRoute(
                  "Get",
                  new { Id = fatura.Id },
                  fatura);
        }

        // DELETE: api/Faturas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Fatura fatura = _dataRepositorio.Get(id);
            if (fatura == null)
            {
                return NotFound("A fatura não foi encontrada.");
            }

            _dataRepositorio.Delete(fatura);
            return NoContent();
        }


    }
}