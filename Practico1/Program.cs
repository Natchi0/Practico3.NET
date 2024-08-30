using DAL.DALs;
using DAL.IDALs;
using Practico1;
using Shared;

IDAL_Personas dalP = new DAL_Personas_EF();
IDAL_Vehiculos dalV = new DAL_Vehiculos_EF();
StartUp startUp = new StartUp();
startUp.UpdateDatabase();

string comando = "NUEVA";
string comandoTipo = "1";

Console.WriteLine("Bienvenido a mi primera app .NET!!!");

do
{
	Console.WriteLine("Elija una opcion:");
	Console.WriteLine("1. Personas");
	Console.WriteLine("2. Vehiculos");
	Console.WriteLine("0. EXIT");

	try
	{
		comandoTipo = Console.ReadLine().ToUpper();

		switch (comandoTipo)
		{
			case "1":
				Console.Clear();
				do
				{
					Console.WriteLine("Ingrese comando (NUEVA/IMPRIMIR/BUSCAR/ELIMINAR/EXIT): ");
					Console.WriteLine("1. NUEVA");
					Console.WriteLine("2. IMPRIMIR");
					Console.WriteLine("3. BUSCAR");
					Console.WriteLine("4. ELIMINAR");
					Console.WriteLine("5. -- Limpiar Consola --");
					Console.WriteLine("0. EXIT");

					try
					{
						comando = Console.ReadLine().ToUpper();

						switch (comando)
						{
							case "NUEVA":
							case "1":

								Persona persona = new Persona();
								Console.WriteLine("Ingrese el nombre de la persona: ");
								persona.Nombre = Console.ReadLine();
								Console.WriteLine("Ingrese el documento de la persona: ");
								persona.Documento = Console.ReadLine();
								Console.WriteLine("Ingrese los apellidos de la persona: ");
								persona.Apellidos = Console.ReadLine();
								Console.WriteLine("Ingrese el telefono de la persona: ");
								persona.Telefono = int.Parse(Console.ReadLine());
								Console.WriteLine("Ingrese la direccion de la persona: ");
								persona.Direccion = Console.ReadLine();
								Console.WriteLine("Ingrese la fecha de nacimiento de la persona (yyyy-mm-dd): ");
								persona.FechaNacimiento = DateOnly.Parse(Console.ReadLine());
								dalP.AddPersona(persona);
								break;

							case "IMPRIMIR":
							case "2":

								List<Persona> filtradas = dalP.GetPersonas().OrderBy(p => p.Id).ToList();

								foreach (Persona p in filtradas)
									Console.WriteLine(p.GetString());
								break;

							case "BUSCAR":
							case "3":

								Console.WriteLine("Ingrese ID:");
								string id = Console.ReadLine();
								Persona per = dalP.GetPersona(long.Parse(id));
								if (per != null)
									Console.WriteLine(per.GetString());
								else
									Console.WriteLine("Persona no encontrada.");
								break;

							case "ELIMINAR":
							case "4":

								Console.WriteLine("Ingrese ID:");
								string id2 = Console.ReadLine();
								dalP.DeletePersona(long.Parse(id2));
								Console.WriteLine("Persona eliminada.");
								break;

							case "5":
								Console.Clear();
								break;

							case "EXIT":
							case "0":
								break;

							default:
								Console.WriteLine("Comando no reconocido.");
								break;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				while (comando != "EXIT");
				break;

			case "2":
				Console.Clear();
				do
				{
					Console.WriteLine("Ingrese comando (NUEVA/IMPRIMIR/BUSCAR/ELIMINAR/EXIT): ");
					Console.WriteLine("1. NUEVA");
					Console.WriteLine("2. IMPRIMIR");
					Console.WriteLine("3. BUSCAR");
					Console.WriteLine("4. ELIMINAR");
					Console.WriteLine("5. -- Limpiar Consola --");
					Console.WriteLine("0. EXIT");

					try
					{
						comando = Console.ReadLine().ToUpper();

						switch (comando)
						{
							case "NUEVA":
							case "1":

								Vehiculo vehiculo = new Vehiculo();
								Console.WriteLine("Ingrese la marca del vehiculo: ");
								vehiculo.Marca = Console.ReadLine();
								Console.WriteLine("Ingrese el modelo del vehiculo: ");
								vehiculo.Modelo = Console.ReadLine();
								Console.WriteLine("Ingrese la matricula del vehiculo: ");
								vehiculo.Matricula = Console.ReadLine();
								Console.WriteLine("Ingrese el id de la persona: ");
								vehiculo.Persona = dalP.GetPersona(long.Parse(Console.ReadLine()));
								dalV.AddVehiculo(vehiculo);
								break;

							case "IMPRIMIR":
							case "2":

								List<Vehiculo> filtrados = dalV.GetVehiculos().OrderBy(v => v.Id).ToList();

								foreach (Vehiculo v in filtrados)
									Console.WriteLine(v.GetString());
								break;

							case "BUSCAR":
							case "3":

								Console.WriteLine("Ingrese ID:");
								string id = Console.ReadLine();
								Vehiculo veh = dalV.GetVehiculo(long.Parse(id));
								if (veh != null)
									Console.WriteLine(veh.GetString());
								else
									Console.WriteLine("Vehiculo no encontrado.");
								break;

							case "ELIMINAR":
							case "4":

								Console.WriteLine("Ingrese ID:");
								string id2 = Console.ReadLine();
								dalV.DeleteVehiculo(long.Parse(id2));
								Console.WriteLine("Vehiculo eliminado.");
								break;

							case "5":
								Console.Clear();
								break;

							case "EXIT":
							case "0":
								break;

							default:
								Console.WriteLine("Comando no reconocido.");
								break;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				while (comando != "EXIT");
				break;

			case "0":
				break;

			default:
				Console.WriteLine("Comando no reconocido.");
				break;
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}
while (comandoTipo != "EXIT");



Console.WriteLine("Hasta luego!!!");
Console.ReadLine();