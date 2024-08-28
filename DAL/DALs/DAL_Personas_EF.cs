using DAL.IDALs;
using DAL.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
	public class DAL_Personas_EF : IDAL_Personas
	{
		public void AddPersona(Persona persona)
		{
			using (var context = new DBContext())
			{
				try
				{
					Personas personas = Personas.FromEntity(persona);
					context.Personas.Add(personas);
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new Exception("Error en la base de datos: " + ex.Message);
				}
			}
		}

		public void DeletePersona(long id)
		{
			using (var context = new DBContext())
			{
				try
				{
					Personas? personas = context.Personas.Find(id);
					if (personas == null)
                    {
                        throw new Exception("Persona no encontrada.");
                    }
					context.Personas.Remove(personas);
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new Exception("Error en la base de datos: " + ex.Message);
				}
			}
		}

		public Persona GetPersona(long id)
		{
			using (var context = new DBContext())
			{
				Personas? persona = context.Personas.Find(id);

				if (persona == null)
                {
                    throw new Exception("Persona no encontrada.");
                } 

				return persona.GetEntity();
			}
		}

		public List<Persona> GetPersonas()
		{
			using (var context = new DBContext())
			{
				return context.Personas.Select(p => p.GetEntity()).ToList();
			}
		}

		public void UpdatePersona(Persona persona)
		{
			using (var context = new DBContext()) 
			{
				try
				{
					Personas? dbPer = context.Personas.Find(persona.Id);
					if (dbPer == null) 
					{
                        throw new Exception("Persona no encontrada.");
                    }
					dbPer.Nombre = persona.Nombre;
					dbPer.Documento = persona.Documento;
					dbPer.Apellidos = persona.Apellidos;
					dbPer.Telefono = persona.Telefono;
					dbPer.Direccion = persona.Direccion;
					dbPer.FechaNacimiento = persona.FechaNacimiento;
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new Exception("Error en la base de datos: " + ex.Message);
				}
			}
		}
	}
}
