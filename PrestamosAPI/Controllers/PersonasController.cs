using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistrosPrestamos.BLL;
using RegistrosPrestamos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Persona>> Get()
        {
            return PersonasBLL.GetList(p => true);
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public ActionResult<Persona> Get(int id)
        {
            return PersonasBLL.Buscar(id);
        }

        // POST api/<PersonaController>
        [HttpPost]
        public ActionResult<Persona> Post(Persona Persona)
        {
            PersonasBLL.Guardar(Persona);

            return CreatedAtAction(nameof(Get), new { id = Persona.PersonaId }, Persona);
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Persona Persona)
        {
            if (id != Persona.PersonaId)
                return BadRequest();

            PersonasBLL.Modificar(Persona);

            return NoContent();
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (PersonasBLL.Buscar(id) != null)
            {
                PersonasBLL.Eliminar(id);
            }
            else
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
