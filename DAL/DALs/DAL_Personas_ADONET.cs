using DAL.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {
        static string cadena = "Data Source=DESKTOP-49TLN0K\\SQLEXPRESS;Initial Catalog=practico1;" +
            "Persist Security Info=True;User ID=sa;Password=UTEC;Encrypt=False";

        public void AddPersona(Persona persona)
        {
            string query = "insert into Personas (Nombre, Documento) values (@Nombre, @Documento)";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Documento", persona.Documento);

                try
                {
                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }

        public void DeletePersona(long id)
        {
            string query = "delete from Personas where Id = @Id";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }

        public Persona GetPersona(long id)
        {
            Persona persona = new Persona();
            string query = "select * from Personas where Id = @Id";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    cn.Open();
                    SqlDataReader datos = command.ExecuteReader();
                    datos.Read();
                    persona.Id = datos.GetInt32(0);
                    persona.Nombre = datos.GetString(1);
                    persona.Documento = datos.GetString(2);
                    cn.Close();
                    datos.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }

            return persona;
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> personas = new List<Persona>();

            string query = "select * from Personas";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand command = new SqlCommand(query, cn);

                try
                {
                    cn.Open();
                    SqlDataReader datos = command.ExecuteReader();
                    while (datos.Read())
                    {

                        Persona persona = new Persona();
                        persona.Id = datos.GetInt32(0);
                        persona.Nombre = datos.GetString(1);
                        persona.Documento = datos.GetString(2);
                        personas.Add(persona);
                    }
                    datos.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }

            return personas;
        }

        public void UpdatePersona(Persona persona)
        {
            string query = "update Personas set Nombre = @Nombre, Documento = @Documento where Id = @Id";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Documento", persona.Documento);
                command.Parameters.AddWithValue("@Id", persona.Id);

                try
                {
                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }
    }
}