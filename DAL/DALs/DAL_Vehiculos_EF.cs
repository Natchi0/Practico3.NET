using DAL.IDALs;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
	public class DAL_Vehiculos_EF : IDAL_Vehiculos
	{
		public void AddVehiculo(Vehiculo vehiculo)
		{
			using (var context = new DBContext())
			{
				try
				{
					Vehiculos vehiculos = Vehiculos.FromEntity(vehiculo);
					context.Vehiculos.Add(vehiculos);
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new Exception("Error en la base de datos: " + ex.Message);
				}
			}
		}

		public void DeleteVehiculo(long id)
		{
			using (var context = new DBContext())
			{
				try
				{
					Vehiculos? vehiculos = context.Vehiculos.Find(id);
					if (vehiculos == null)
                    {
                        throw new Exception("Vehiculo no encontrado.");
                    }
					context.Vehiculos.Remove(vehiculos);
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new Exception("Error en la base de datos: " + ex.Message);
				}
			}
		}

		public Vehiculo GetVehiculo(long id)
		{
			using (var context = new DBContext())
			{
				var vehiculo = context.Vehiculos.Include(v => v.Persona).FirstOrDefault(v => v.Id == id);

				if (vehiculo == null)
				{
					throw new Exception("Vehiculo no encontrado.");
				}

				return vehiculo.GetEntity();
			}
		}

		public List<Vehiculo> GetVehiculos()
		{
			using(var context = new DBContext())
			{
				return context.Vehiculos.Include(v => v.Persona).Select(v => v.GetEntity()).ToList();
			}
		}

		public void UpdateVehiculo(Vehiculo vehiculo)
		{
			using(var context = new DBContext())
			{
				try
				{
					Vehiculos? vehiculos = context.Vehiculos.Find(vehiculo.Id);
					if (vehiculos == null)
					{
						throw new Exception("Vehiculo no encontrado.");
					}
					vehiculos.Marca = vehiculo.Marca;
					vehiculos.Modelo = vehiculo.Modelo;
					vehiculos.Matricula = vehiculo.Matricula;
					vehiculos.PersonaId = vehiculo.Persona.Id;
					
                    context.SaveChanges();
                }
                catch (Exception ex)
				{
					throw new Exception("Error en la base de datos: " + ex.Message);
				}
			}
		}

		public List<Vehiculo> GetVehiculosByPersona(long id)
		{
			using(var context = new DBContext())
			{
				return context.Vehiculos.Where(v => v.PersonaId == id).Select(v => v.GetEntity()).ToList();
			}
		}

	}
}
