using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Personas
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public long Id { get; set; }
		public string Nombre { get; set; } = "";
		public string Documento { get; set; } = "";

		public string Apellidos { get; set; } = "";

		public int Telefono { get; set; }

		public string Direccion { get; set; } = "";

		public DateOnly FechaNacimiento { get; set; }
		public virtual List<Vehiculos> Vehiculos { get; set; }

		public Persona GetEntity()
		{
			return new Persona()
			{
				Id = Id,
				Nombre = Nombre,
				Documento = Documento,
				Apellidos = Apellidos,
				Telefono = Telefono,
				Direccion = Direccion,
				FechaNacimiento = FechaNacimiento
			};
		}

		public static Personas FromEntity(Persona persona)
		{
			return new Personas()
			{
				Id = persona.Id,
				Nombre = persona.Nombre,
				Documento = persona.Documento,
				Apellidos = persona.Apellidos,
				Telefono = persona.Telefono,
				Direccion = persona.Direccion,
				FechaNacimiento = persona.FechaNacimiento
			};
		}
	}
}
