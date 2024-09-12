using Microsoft.AspNetCore.Mvc;
using BusinessLayer.IBLs;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehiculosController : ControllerBase
	{

		private readonly IBL_Vehiculos _bl;

		public VehiculosController(IBL_Vehiculos bl)
		{
			_bl = bl;
		}

		//GET: api/<VehiculosController>
		[ProducesResponseType(typeof(List<Vehiculo>), 200)]
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_bl.GetVehiculos());
		}

		//GET api/<VehiculosController>/12345678
		[ProducesResponseType(typeof(Vehiculo), 200)]
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			return Ok(_bl.GetVehiculo(id));
		}

		// POST api/<VehiculosController>
		[ProducesResponseType(typeof(Vehiculo), 200)]
		[HttpPost]
		public IActionResult Post([FromBody] Vehiculo vehiculo)
		{
			_bl.AddVehiculo(vehiculo);
			return Ok(vehiculo);
		}

		// PUT api/<VehiculosController>/5
		[ProducesResponseType(typeof(Vehiculo), 200)]
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Vehiculo vehiculo)
		{
			vehiculo.Id = id;
			_bl.UpdateVehiculo(vehiculo);
			return Ok(vehiculo);
		}

		// DELETE api/<VehiculosController>/5
		[ProducesResponseType(typeof(Vehiculo), 200)]
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			_bl.DeleteVehiculo(id);
			return Ok();
		}
		
		//GET api/<VehiculosController>/GetVehiculosByPersona/5
		[ProducesResponseType(typeof(List<Vehiculo>), 200)]
		[HttpGet("GetVehiculosByPersona/{id}")]
		public IActionResult GetVehiculosByPersona(long id)
        {
            return Ok(_bl.GetVehiculosByPersona(id));
        }
	}
}
