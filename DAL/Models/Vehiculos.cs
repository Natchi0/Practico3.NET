using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Vehiculos
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public long Id { get; set; }
		public string Marca { get; set; } = "";
		public string Modelo { get; set; } = "";
		public string Matricula { get; set; } = "";

        public long PersonaId { get; set; }

        [ForeignKey("PersonaId")]
        public Personas Persona { get; set; }

        public Vehiculo GetEntity()
        {
            Console.WriteLine("persona: " + Persona.Nombre);
            return new Vehiculo
            {
                Id = Id,
                Marca = Marca,
                Modelo = Modelo,
                Matricula = Matricula,
                Persona = Persona.GetEntity()
            };
        }

        public static Vehiculos FromEntity(Vehiculo vehiculo)
        {
            Console.WriteLine("persona: " + vehiculo.Persona.Nombre);
            return new Vehiculos()
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Matricula = vehiculo.Matricula,
                PersonaId = vehiculo.Persona.Id 
            };
        }
    }
}
