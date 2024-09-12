using Microsoft.AspNetCore.Mvc;
using BusinessLayer.IBLs;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly IBL_Personas _bl;

        public PersonasController(IBL_Personas bl)
        {
            _bl = bl;
        }

        //GET: api/<PersonasController>
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.GetPersonas());
        }

        //GET api/<PersonasController>/12345678
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_bl.GetPersona(id));
        }

        // POST api/<PersonasController>
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            _bl.AddPersona(persona);
            return Ok(persona);
        }

        // PUT api/<PersonasController>/5
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Persona persona)
        {
            persona.Id = id;
            _bl.UpdatePersona(persona);
            return Ok(persona);
        }

        // DELETE api/<PersonasController>/5
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bl.DeletePersona(id);
            return Ok();
        }
    }
}