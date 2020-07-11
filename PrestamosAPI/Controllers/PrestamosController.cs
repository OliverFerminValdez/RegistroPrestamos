using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistrosPrestamos.BLL;
using RegistrosPrestamos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrestamosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        // GET: api/<PrestamosController>
        [HttpGet]
        public ActionResult<IEnumerable<Prestamo>> Get()
        {
            return PrestamosBLL.GetList(p => true);
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public ActionResult<Prestamo> Get(int id)
        {
            return PrestamosBLL.Buscar(id);
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public ActionResult<Prestamo> Post(Prestamo prestamo)
        {
            PrestamosBLL.Guardar(prestamo);

            return CreatedAtAction(nameof(Get), new { id = prestamo.PrestamoId }, prestamo);
        }

        // PUT api/<PrestamosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Prestamo prestamo)
        {
            if (id != prestamo.PrestamoId)
                return BadRequest();

            PrestamosBLL.Modificar(prestamo);

            return NoContent();
        }

        // DELETE api/<PrestamosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (PrestamosBLL.Buscar(id) != null)
            {
                PrestamosBLL.Eliminar(id);
            }
            else
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}