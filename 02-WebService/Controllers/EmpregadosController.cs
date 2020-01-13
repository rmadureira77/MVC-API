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
    public class EmpregadosController : ControllerBase
    {
        private readonly IDataRepositorio<Empregado> _dataRepositorio;

        public EmpregadosController(IDataRepositorio<Empregado> dataRepositorio)
        {
            _dataRepositorio = dataRepositorio;
        }

       
        // GET: api/Empregados
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Empregado> empregados = _dataRepositorio.GetAll();
            return Ok(empregados);
        }

        // GET: api/Empregados/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Empregado empregado = _dataRepositorio.Get(id);

            if (empregado == null)
            {
                return NotFound("Empregado inexistente.");
            }

            return Ok(empregado);
        }

        // PUT: api/Empregados/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empregado empregado)
        {
            if (empregado == null)
            {
                return BadRequest("Empregado inexistente.");
            }

            Empregado empregadoToUpdate = _dataRepositorio.Get(id);
            if (empregadoToUpdate == null)
            {
                return NotFound("O empregado não foi encontrado.");
            }

            _dataRepositorio.Update(empregadoToUpdate, empregado);
            return NoContent();
        }

        // POST: api/Empregados
        [HttpPost]
        public IActionResult Post([FromBody] Empregado empregado)
        {
            if (empregado == null)
            {
                return BadRequest("Empregado não existe.");
            }

            _dataRepositorio.Add(empregado);
            return CreatedAtRoute(
                  "Get",
                  new { Id = empregado.Id },
                  empregado);
        }

        // DELETE: api/Empregados/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Empregado empregado = _dataRepositorio.Get(id);
            if (empregado == null)
            {
                return NotFound("O empregado não foi encontrado.");
            }

            _dataRepositorio.Delete(empregado);
            return NoContent();
        }

        
    }
}
