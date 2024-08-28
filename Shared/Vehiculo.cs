using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Matricula { get; set; } = "";

        public Persona Persona { get; set; }

        public string GetString()
        {
            return $"Id: {Id}, Marca: {Marca}, Modelo: {Modelo}, Matricula: {Matricula}, Persona: {Persona.Nombre}";
        }

    }
}
